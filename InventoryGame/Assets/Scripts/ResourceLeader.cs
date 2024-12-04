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
    [SerializeField] private GameObject _loadedItemPrefab;
    [SerializeField] private Transform rootPlaceIcons;

    [SerializeField] private InventoryItemSO inventoryItem;
    private InventoryItemSO _loadedInventoryItem;

    InventoryItemSO[] inventoryItemSOs;
    private Sprite[] itemSprites;


    

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



        //Debug.Log(inventoryItem.Name);
        //Debug.Log(inventoryItem.Cost);

        //Debug.Log(_loadedBulletPrefab);

        //_loadedBulletPrefab = Resources.Load("Prefabs/Bullet") as GameObject;
        //_loadedRubyPrefab = Resources.Load("Prefabs/CutRuby") as GameObject;

        //Debug.Log(itemsPrefabs.Length);

        //Debug.Log(_loadedBulletPrefab);
    }
    public void InstantiateItems()
    {
        GameObject instance = Instantiate(_loadedItemPrefab, rootForItems);

        //GameObject instance = Instantiate(itemsPrefabs[Random.Range(0, itemsPrefabs.Length)]);

        var itemScript = instance.GetComponent<Item>();

        foreach (var itemSO in inventoryItemSOs)
        {
            //Debug.Log($"{item.Name} - {item.Cost}");

            //Debug.Log(item);

            //foreach (var root in roots)
            //{

            //foreach (var prefab in itemsPrefabs)
            //Debug.Log($"{itemScript.itemName} - {itemSO.Name}");
            //Debug.Log(itemSO.name);
            //{
            //    Destroy(instance);
            //}
            //else
            //Debug.Log(instance);

            //var element = myArray[Random.Range(0, myArray.Length)];



            //var randomItem = itemSO(inventoryItemSOs[Random.Range(0, inventoryItemSOs.Length)]);

            var randomItemSO = inventoryItemSOs[Random.Range(0, inventoryItemSOs.Length)];

            //Debug.Log(instance);
                //Debug.Log($"{itemSO.Name} - {itemSO.Cost} - {itemSO.Class} - {itemSO.Stats} -  {itemSO.Sprite}");

            itemScript.SetupItem(/*itemSO.Id,*/ randomItemSO.Name, randomItemSO.Cost, randomItemSO.Class, randomItemSO.Stats, randomItemSO.Sprite);


            //}
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

        itemSprites = Resources.LoadAll("SpritesRPG/Potion", typeof(Sprite))
            .Cast<Sprite>()
            .ToArray();
        Debug.Log(itemSprites.Length);
    }
}