using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ItemsFabric : MonoBehaviour
{
    [SerializeField] private GameObject _loadedItemPrefab;
    [SerializeField] private Transform rootForItems;

    [SerializeField] private InventoryItemSO inventoryItem;
    private InventoryItemSO _loadedInventoryItem;

    InventoryItemSO[] inventoryItemSOs;

    [SerializeField] private int _itemsMaxAmount = 20;
    private int _createdItemsAmount = 0;

    void Start()
    {
        LoadResources();
        _loadedInventoryItem = Resources.Load("InventoryItemSO") as InventoryItemSO;
    }
    public void InstantiateItems()
    {
        if (_createdItemsAmount < _itemsMaxAmount)
        {
            _createdItemsAmount++;

            GameObject instance = Instantiate(_loadedItemPrefab, rootForItems);

            Item itemScript = instance.GetComponent<Item>();

            foreach (var itemSO in inventoryItemSOs)
            {
                var randomItemSO = inventoryItemSOs[Random.Range(0, inventoryItemSOs.Length)];

                itemScript.SetupItem(randomItemSO.Name, randomItemSO.Cost, randomItemSO.Class, randomItemSO.Stats, randomItemSO.Sprite, randomItemSO.DestroyInPercentsFrom0To1);
            }
        }
    }

    public void AllignAfterDestroy(int destroyedAmount)
    {
        _createdItemsAmount -= destroyedAmount;
    }

    private void LoadResources()
    {
        inventoryItemSOs = Resources.LoadAll("SO/InventoryItems", typeof(InventoryItemSO))
            .Cast<InventoryItemSO>()
            .ToArray();
    }

    public int GetItemsMaxAmount() => _itemsMaxAmount;
}