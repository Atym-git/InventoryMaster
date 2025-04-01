using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Item : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string itemName;
    public string itemClass;
    public int stats;
    public int cost;
    private Image _itemImage;
    private float _percentageDestroy;
    public int id;

    private DisplayItemInfo displayItemInfo;
    private ItemsDestroyer itemsDestroyer;

    private void Awake()
    {
        displayItemInfo = FindFirstObjectByType<DisplayItemInfo>();
        itemsDestroyer = FindFirstObjectByType<ItemsDestroyer>();
        _itemImage = GetComponent<Image>();
    }

    public void SetupItem(string Name, int Cost, string Class, int Stats, Sprite ItemSprite, float percentageDestroy, int Id)
    {
        itemName = Name;
        cost = Cost;
        stats = Stats;
        itemClass = Class;
        _itemImage.sprite = ItemSprite;
        _percentageDestroy = percentageDestroy;
        id = Id;
    }

    private void Start()
    {
        itemsDestroyer.DestroyItems(_percentageDestroy);
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        displayItemInfo.DisplayInfo(itemName, cost, itemClass, stats, _itemImage.sprite);
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        displayItemInfo.StopDisplayInfo();
    }
}