using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ResourceLeader : MonoBehaviour
{
    private GameObject _loadedBulletPrefab;
    [SerializeField] private Transform rootForItems;

    [SerializeField] private GameObject _loadedIconsPlacement;
    [SerializeField] private Transform rootPlaceIcons;

    [SerializeField] private InventoryItemSO inventoryItem;
    private InventoryItemSO _loadedInventoryItem;

    InventoryItemSO[] inventoryItemSOs;
    private GameObject[] itemsPrefabs;

    

    void Start()
    {
        LoadResources();
        for (int i = 0; i < 20; i++)
        {
            GameObject IconsPlacement = Instantiate(_loadedIconsPlacement);

            IconsPlacement.transform.SetParent(rootPlaceIcons, false);
        }

        //Debug.Log(inventoryItem.Name);
        //Debug.Log(inventoryItem.Cost);

        _loadedInventoryItem = Resources.Load("InventoryItemSO") as InventoryItemSO;



        Debug.Log(inventoryItem.Name);
        Debug.Log(inventoryItem.Cost);

        //Debug.Log(_loadedBulletPrefab);

        //_loadedBulletPrefab = Resources.Load("Prefabs/Bullet") as GameObject;
        //_loadedRubyPrefab = Resources.Load("Prefabs/CutRuby") as GameObject;

        //Debug.Log(itemsPrefabs.Length);

        //Debug.Log(_loadedBulletPrefab);
    }
    public void InstantiateItems()
    {
        foreach (var itemSO in inventoryItemSOs)
        {
            //Debug.Log($"{item.Name} - {item.Cost}");

            //Debug.Log(item);

            //foreach (var root in roots)
            //{

            foreach (var prefab in itemsPrefabs)
            {
                var itemScript = prefab.GetComponent<Item>();
                if (itemScript.id == itemSO.Id)
                {
                    GameObject instance = Instantiate(prefab);
                    instance.transform.SetParent(rootForItems, false);

                    Debug.Log(instance);

                    if (instance.TryGetComponent(out Item itemInstance))
                    {
                        Debug.Log(itemInstance);
                        Debug.Log(instance);
                        itemInstance.SetupItem(itemSO.Id, itemSO.Name, itemSO.Cost, itemSO.Class, itemSO.MainStat);
                    }
                }
            }
            //}
        }
    }

    private void LoadResources()
    {
        //Debug.Log("LoadingResources");
        inventoryItemSOs = Resources.LoadAll("InventoryItems", typeof(InventoryItemSO))
            .Cast<InventoryItemSO>()
            .ToArray();

        //Debug.Log(inventoryItemSOs.Length);

        //_loadedBulletPrefab = Resources.Load("Bone", typeof (InventoryItemSO/*, typeof(InventoryItemSO)*/)) as GameObject;
        //    //.Cast<InventoryItemSO>()
        //    //.ToArray();
        //Debug.Log(inventoryItemSOs.Length);
        //Debug.Log(_loadedBulletPrefab);

        itemsPrefabs = Resources.LoadAll("Prefabs", typeof(GameObject))
            .Cast<GameObject>()
            .ToArray();
    }
}