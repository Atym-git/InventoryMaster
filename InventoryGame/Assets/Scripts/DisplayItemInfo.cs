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
    //[SerializeField] private GameObject DisplayIcon;
    [SerializeField] private Image itemImage;

    private Item itemScript;

    private void Update()
    {
        itemScript = FindObjectOfType<Item>();
        
    }


    public void DisplayInfo(string Name, int Cost, string Class, int Stats, Sprite ItemSprite)
    {
        //if (pointedItem == itemScript.GetInstanceID())
        //{
            nameTMP.text = Name;
            classTMP.text = Class;
            costTMP.text = Cost.ToString();
            statsTMP.text = Stats.ToString();
            itemImage.gameObject.SetActive(true);
            itemImage.sprite = ItemSprite;

        //}
    }
    public void StopDisplayInfo()
    {
        nameTMP.text = "Название";
        classTMP.text = "Класс";
        costTMP.text = "Стоимость";
        statsTMP.text = "Статы";
        itemImage.gameObject.SetActive(false);
    }
}
