using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Item : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] public string _itemName;
    [SerializeField] public string _itemClass;
    [SerializeField] public int _stats;
    [SerializeField] public int _cost;
    [SerializeField] private Image _itemImage;
    private float _percentageDestroy;

    private DisplayItemInfo displayItemInfo;
    private ItemsDestroyer itemsDestroyer;

    private void Awake()
    {
        displayItemInfo = FindFirstObjectByType<DisplayItemInfo>();
        itemsDestroyer = FindFirstObjectByType<ItemsDestroyer>();
        _itemImage = GetComponent<Image>();
    }

    public void SetupItem(string Name, int Cost, string Class, int Stats, Sprite ItemSprite, float percentageDestroy)
    {
        _itemName = Name;
        _cost = Cost;
        _stats = Stats;
        _itemClass = Class;
        _itemImage.sprite = ItemSprite;
        _percentageDestroy = percentageDestroy;
    }

    private void Start()
    {
        itemsDestroyer.DestroyItems(_percentageDestroy);
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        displayItemInfo.DisplayInfo(_itemName, _cost, _itemClass, _stats, _itemImage.sprite);
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        displayItemInfo.StopDisplayInfo();
    }
}