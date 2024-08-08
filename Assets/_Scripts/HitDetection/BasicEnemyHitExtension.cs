using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyHitExtension :  MonoBehaviour, Hittable
{

    public void Awake()
    {
        Debug.Log("enemy awake");
    }

    public void Hit()
    {
        Debug.Log("Hit");
    }
}
