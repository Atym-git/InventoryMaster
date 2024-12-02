using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ResourceLeader : MonoBehaviour
{
    private GameObject _loadedBulletPrefab;
    [SerializeField] private Transform root;

    [SerializeField] private GameObject _loadedIconsPlacement;
    [SerializeField] private Transform rootPlaceIcons;

    private InventoryItemSO inventoryItem;
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

        // _loadedInventoryItem = Resources.Load("InventoryItemSO") as InventoryItemSO;

        //Debug.Log(inventoryItem.Name);
        //Debug.Log(inventoryItem.Cost);

        //Debug.Log(_loadedBulletPrefab);

        _loadedBulletPrefab = Resources.Load("Prefabs/Bullet") as GameObject;
        //_loadedRubyPrefab = Resources.Load("Prefabs/CutRuby") as GameObject;

        Debug.Log(itemsPrefabs.Length);

        Debug.Log(_loadedBulletPrefab);
    }
    public void InstantiateItems()
    {
        foreach (var item in inventoryItemSOs)
        {
            Debug.Log($"{item.Name} - {item.Cost}");

            //foreach (var root in roots)
            //{
            GameObject instance = Instantiate(itemsPrefabs[Random.Range(0, itemsPrefabs.Length)]);
            instance.transform.SetParent(root, false);

            if (instance.TryGetComponent(out Bullet bulletInstance))
            {
                //Debug.Log(bulletInstance);
                bulletInstance.SetupBullet(item.Name, item.Cost);
            }
            //}
        }
    }

    private void LoadResources()
    {
        inventoryItemSOs = Resources.LoadAll("InventoryItemSO", typeof(InventoryItemSO))
            .Cast<InventoryItemSO>()
            .ToArray();

        itemsPrefabs = Resources.LoadAll("Prefabs", typeof(GameObject))
            .Cast<GameObject>()
            .ToArray();
    }
}
