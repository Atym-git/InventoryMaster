using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ItemsFabric : MonoBehaviour, IDataPersistence
{
    [SerializeField] private GameObject _loadedItemPrefab;
    [SerializeField] private Transform rootForItems;

    [SerializeField] private InventoryItemSO inventoryItem;
    private InventoryItemSO _loadedInventoryItem;

    private InventoryItemSO[] inventoryItemSOs;

    [SerializeField] private int _itemsMaxAmount = 20;
    private int _itemsLeftToLoad = 0;

    void Start()
    {
        LoadResources();
        _loadedInventoryItem = Resources.Load("InventoryItemSO") as InventoryItemSO;
    }
    public void InstantiateItems()
    {
        if (rootForItems.childCount < _itemsMaxAmount)
        {
            if (_itemsLeftToLoad > 0)
            {
                for (int i = 0; i < _itemsLeftToLoad; i++)
                {
                    InstantiateItem();
                }
            }
            else
            {
                InstantiateItem();
            }

        }
    }

    private void InstantiateItem()
    {
        GameObject instance = Instantiate(_loadedItemPrefab, rootForItems);

        Item itemScript = instance.GetComponent<Item>();

        foreach (var itemSO in inventoryItemSOs)
        {
            var randomItemSO = inventoryItemSOs[Random.Range(0, inventoryItemSOs.Length)];

            itemScript.SetupItem(randomItemSO.Name, randomItemSO.Cost, randomItemSO.Class, randomItemSO.Stats,
                randomItemSO.Sprite, randomItemSO.DestroyInPercentsFrom0To1, randomItemSO.Id);
        }
    }

    private void LoadResources()
    {
        inventoryItemSOs = Resources.LoadAll("SO/InventoryItems", typeof(InventoryItemSO))
            .Cast<InventoryItemSO>()
            .ToArray();
    }

    public int GetItemsMaxAmount() => _itemsMaxAmount;

    public void LoadData(GameData gameData)
    {
        _itemsLeftToLoad = gameData.itemCount;
    }

    public void SaveData(ref GameData gameData)
    {
        gameData.itemCount = rootForItems.childCount;
        for (int i = 0; i < rootForItems.childCount; i++)
        {
            gameData.itemsIds[i] = rootForItems.GetChild(i).GetComponent<Item>().id;
        }
    }
}