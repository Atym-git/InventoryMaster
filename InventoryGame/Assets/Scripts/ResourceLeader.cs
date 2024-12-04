using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ResourceLeader : MonoBehaviour
{
    [SerializeField] private GameObject _loadedItemPrefab;
    [SerializeField] private Transform rootForItems;

    [SerializeField] private GameObject _loadedIconsPlacement;
    [SerializeField] private Transform rootPlaceIcons;

    [SerializeField] private InventoryItemSO inventoryItem;
    private InventoryItemSO _loadedInventoryItem;

    InventoryItemSO[] inventoryItemSOs;

    private int _amountOfLoadedItems = 0;
    

    void Start()
    {
        LoadResources();
        for (int i = 0; i < 20; i++)
        {
            GameObject IconsPlacement = Instantiate(_loadedIconsPlacement);

            IconsPlacement.transform.SetParent(rootPlaceIcons, false);
        }

        _loadedInventoryItem = Resources.Load("InventoryItemSO") as InventoryItemSO;
    }
    public void InstantiateItems()
    {
        if (_amountOfLoadedItems < 20)
        {
            _amountOfLoadedItems++;

            GameObject instance = Instantiate(_loadedItemPrefab, rootForItems);

            Item itemScript = instance.GetComponent<Item>();

            foreach (var itemSO in inventoryItemSOs)
            {
                var randomItemSO = inventoryItemSOs[Random.Range(0, inventoryItemSOs.Length)];

                itemScript.SetupItem( randomItemSO.Name, randomItemSO.Cost, randomItemSO.Class, randomItemSO.Stats, randomItemSO.Sprite);
            }
        }
    }

    private void LoadResources()
    {
        inventoryItemSOs = Resources.LoadAll("InventoryItems", typeof(InventoryItemSO))
            .Cast<InventoryItemSO>()
            .ToArray();
    }
}