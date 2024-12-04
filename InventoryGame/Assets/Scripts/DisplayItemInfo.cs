using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayItemInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameTMP;
    [SerializeField] private TextMeshProUGUI classTMP;
    [SerializeField] private TextMeshProUGUI costTMP;
    [SerializeField] private TextMeshProUGUI statsTMP;
    [SerializeField] private GameObject DisplayIcon;
    [SerializeField] private Image itemImage;

    private Item itemScript;

    private void Update()
    {
        itemScript = FindObjectOfType<Item>();
    }


    public void DisplayInfo(System.Int32 pointedItem, Image ItemImage)
    {
        if (pointedItem == itemScript.GetInstanceID())
        {
            nameTMP.text = itemScript.itemName;
            classTMP.text = itemScript.itemClass;
            costTMP.text = itemScript.cost.ToString();
            statsTMP.text = itemScript.stats.ToString();

        }
    }
    public void StopDisplayInfo()
    {
        nameTMP.text = "Название";
        classTMP.text = "Класс";
        costTMP.text = "Стоимость";
        statsTMP.text = "Статы";
        itemScript = null;
    }
}
