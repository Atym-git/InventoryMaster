using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenAchest : MonoBehaviour
{
    [SerializeField] private Button openAChestButton;

    [SerializeField] ResourceLeader resourceLoaderScript;

    private void Start() => OpenAChest();

    private void OpenAChest() => openAChestButton.onClick.AddListener(resourceLoaderScript.InstantiateItems);
}
