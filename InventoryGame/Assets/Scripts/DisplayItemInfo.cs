using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayItemInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameTMP;
    [SerializeField] private TextMeshProUGUI classTMP;
    [SerializeField] private TextMeshProUGUI costTMP;
    [SerializeField] private TextMeshProUGUI mainStatTMP;

    private Item itemScript;
    
    public void DisplayInfo()
    {
        itemScript = GetComponent<Item>();
        nameTMP.text = itemScript.nameItem;
        classTMP.text = itemScript.classItem;
        costTMP.text = itemScript.cost.ToString();
        mainStatTMP.text = itemScript.mainStat;
    }
    public void StopDisplayInfo()
    {
        nameTMP.text = "";
        classTMP.text = "";
        costTMP.text = "";
        mainStatTMP.text = "";
        itemScript = null;
    }
}
