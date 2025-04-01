using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int itemCount;

    public List<int> itemsIds;

    public GameData()
    {
        itemCount = 0;
        itemsIds = new List<int>();
    }
}
