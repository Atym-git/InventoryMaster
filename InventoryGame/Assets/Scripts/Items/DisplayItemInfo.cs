using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayItemInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _nameTMP;
    [SerializeField] private TextMeshProUGUI _classTMP;
    [SerializeField] private TextMeshProUGUI _costTMP;
    [SerializeField] private TextMeshProUGUI _statsTMP;
    [SerializeField] private Image _itemImage;

    private string _naming;
    private string _itemClass;
    private string _cost;
    private string _stats;

    private void Start()
    {
        _naming = _nameTMP.text;
        _itemClass = _classTMP.text;
        _cost = _costTMP.text;
        _stats = _statsTMP.text;
    }

    public void DisplayInfo(string Name, int Cost, string Class, int Stats, Sprite ItemSprite)
    {
        _nameTMP.text = Name;
        _classTMP.text = Class;
        _costTMP.text = Cost.ToString();
        _statsTMP.text = Stats.ToString();
        _itemImage.gameObject.SetActive(true);
        _itemImage.sprite = ItemSprite;
    }
    public void StopDisplayInfo()
    {
        _nameTMP.text = _naming;
        _classTMP.text = _itemClass;
        _costTMP.text = _cost;
        _statsTMP.text = _stats;
        _itemImage.gameObject.SetActive(false);
    }
}
