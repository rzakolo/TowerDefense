using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefabs;
    Vector2[] spawnPos;
    float repeatRate = 3;
    void Start()
    {
        InvokeRepeating(nameof(SpawnWave), 3f, repeatRate);
    }

    void Update()
    {
        
    }
    void SpawnWave() 
    {
        foreach (GameObject enemy in enemyPrefabs)
        {
            Instantiate(enemy);
        }
    }
}
