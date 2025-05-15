using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemy;
    public GameObject spawnPoint;
    public Transform parent;
    
    public float firstCreateEnemyTime;
    public float createEnemyTime;

    private void Start()
    {
        InvokeRepeating("Spawn",firstCreateEnemyTime,createEnemyTime);
    }
    

    private void Spawn()
    {
        Instantiate(enemy,spawnPoint.transform.position,spawnPoint.transform.rotation,parent);
    }
}
