using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] public string nameItem;
    [SerializeField] public string classItem;
    [SerializeField] public string mainStat;
    [SerializeField] public int cost;
    [SerializeField] public int id;

    private DisplayItemInfo displayItemInfo;

    public Item itemScript;

    private void Awake()
    {
        displayItemInfo = FindFirstObjectByType<DisplayItemInfo>();
    }


    public void SetupItem(int Id, string Name, int Cost, string Class, string MainStat)
    {
        id = Id;
        nameItem = Name;
        cost = Cost;
        mainStat = MainStat;
        classItem = Class;
    }
    private void OnMouseEnter()
    {
        Debug.Log(displayItemInfo);
        itemScript = GetComponent<Item>();
        displayItemInfo.DisplayInfo();
    }
    private void OnMouseExit()
    {
        Debug.Log(displayItemInfo);
        itemScript = null;
        displayItemInfo.StopDisplayInfo();
    }
    
}