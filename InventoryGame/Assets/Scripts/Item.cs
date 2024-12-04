using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Item : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] public string itemName;
    [SerializeField] public string itemClass;
    [SerializeField] public int stats;
    [SerializeField] public int cost;
    [SerializeField] private Image _itemImage;

    private DisplayItemInfo displayItemInfo;

    private void Awake()
    {
        displayItemInfo = FindFirstObjectByType<DisplayItemInfo>();
        _itemImage = GetComponent<Image>();
    }


    public void SetupItem(string Name, int Cost, string Class, int Stats, Sprite ItemSprite)
    {
        itemName = Name;
        cost = Cost;
        stats = Stats;
        itemClass = Class;
        _itemImage.sprite = ItemSprite;
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