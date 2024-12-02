using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenAchest : MonoBehaviour
{
    [SerializeField] private Button openAChestButton;

    ResourceLeader resourceLoaderScript;

    private void OpenAChest() => openAChestButton.onClick.AddListener(resourceLoaderScript.InstantiateItems);
}
