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
    //[SerializeField] public int id;
    [SerializeField] private Image _itemImage;
    //[SerializeField] public Sprite itemSprite;

    private DisplayItemInfo displayItemInfo;

    public Item itemScript;

    private void Awake()
    {
        displayItemInfo = FindFirstObjectByType<DisplayItemInfo>();
        _itemImage = GetComponent<Image>();
    }


    public void SetupItem(string Name, int Cost, string Class, int Stats, Sprite ItemSprite)
    {
        //id = Id;
        itemName = Name;
        cost = Cost;
        stats = Stats;
        itemClass = Class;
        _itemImage.sprite = ItemSprite;
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        //Output to console the GameObject's name and the following message
        //var pointedItem = GetInstanceID();
        displayItemInfo.DisplayInfo(itemName, cost, itemClass, stats, _itemImage.sprite);
        Debug.Log($"Cursor Entering + {GetInstanceID()} + GameObject");
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        //Output the following message with the GameObject's name
        Debug.Log("Cursor Exiting " + name + " GameObject");
        displayItemInfo.StopDisplayInfo();
    }

    //private void OnMouseEnter()
    //{
    //    Debug.Log(displayItemInfo);
    //    itemScript = GetComponent<Item>();
    //    displayItemInfo.DisplayInfo();
    //}
    //private void OnMouseExit()
    //{
    //    Debug.Log(displayItemInfo);
    //    itemScript = null;
    //    displayItemInfo.StopDisplayInfo();
    //}

}