using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ResourceLeader : MonoBehaviour
{
    private GameObject _loadedBulletPrefab;
    [SerializeField] private Transform root;
    [SerializeField] private InventoryItemSO inventoryItem;
    private InventoryItemSO _loadedInventoryItem;
    void Start()
    {
        //Debug.Log(inventoryItem.Name);
        //Debug.Log(inventoryItem.Cost);

        // _loadedInventoryItem = Resources.Load("InventoryItemSO") as InventoryItemSO;

        //Debug.Log(inventoryItem.Name);
        //Debug.Log(inventoryItem.Cost);

        _loadedBulletPrefab = Resources.Load("Prefabs/Bullet") as GameObject;

        InventoryItemSO[] inventoryItemSOs =
            Resources.LoadAll("InventoryItemSO", typeof(InventoryItemSO))
            .Cast<InventoryItemSO>()
            .ToArray();

        //Debug.Log(inventoryItemSOs.Length);

        foreach (var item in inventoryItemSOs)
        {
            //Debug.Log($"{item.Name} - {item.Cost}");


            GameObject instance = Instantiate(_loadedBulletPrefab, root);
            if (instance.TryGetComponent(out Bullet bulletInstance))
            {
                bulletInstance.SetupBullet(item.Name, item.Cost);
            }
        }
    }
}
