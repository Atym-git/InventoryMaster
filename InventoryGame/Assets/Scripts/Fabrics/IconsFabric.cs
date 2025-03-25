using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconsFabric : MonoBehaviour
{
    [SerializeField] private GameObject _iconPrefab;
    [SerializeField] private Transform _iconsRoot;

    [SerializeField] private ItemsFabric itemsFabric;
    private void Start()
    {
        SpawnIcons();
    }

    private void SpawnIcons()
    {
        for (int i = 0; i < itemsFabric.GetItemsMaxAmount(); i++)
        {
            GameObject IconsPlacement = Instantiate(_iconPrefab);

            IconsPlacement.transform.SetParent(_iconsRoot, false);
        }
    }
}
