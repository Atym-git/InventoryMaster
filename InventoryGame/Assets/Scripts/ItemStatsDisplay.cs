using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemStatsDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameTMP;
    [SerializeField] private TextMeshProUGUI classTMP;
    [SerializeField] private TextMeshProUGUI costTMP;
    [SerializeField] private TextMeshProUGUI mainStatTMP;

    private string startingName;
    private string startingClass;
    private string startingCost;
    private string startingMainStat;

    [SerializeField] InventoryItemSO InventoryItemSO;

    private void Start()
    {
        startingName = nameTMP.text;
        startingClass = classTMP.text;
        startingCost = costTMP.text;
        startingMainStat = mainStatTMP.text;

        nameTMP = FindAnyObjectByType<TextMeshProUGUI>();
    }

    private void OnMouseEnter()
    {
        nameTMP.text = InventoryItemSO.Name;
        classTMP.text = InventoryItemSO.Class;
        costTMP.text = InventoryItemSO.Cost.ToString();
        mainStatTMP.text = InventoryItemSO.Stats.ToString();

    }
    private void OnMouseExit()
    {
        nameTMP.text = startingName;
        classTMP.text = startingClass;
        costTMP.text = startingCost;
        mainStatTMP.text = startingMainStat;
    }
}
