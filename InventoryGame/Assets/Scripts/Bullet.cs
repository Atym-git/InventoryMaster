using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private int _cost;

    public void SetupBullet(string name, int cost)
    {
        _name = name;
        _cost = cost;
    }
}
