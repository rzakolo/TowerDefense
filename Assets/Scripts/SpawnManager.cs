using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefabs;
    GameManager gameManager;
    Vector2[] spawnPos;
    [SerializeField] float repeatRate = 3f;
    [SerializeField] float spawnTime = 3f;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        InvokeRepeating(nameof(SpawnWave), spawnTime, repeatRate);
    }
    void SpawnWave()
    {
        foreach (GameObject enemy in enemyPrefabs)
        {
            enemy.transform.position = transform.position;
            Instantiate(enemy);
        }
        gameManager.UpdateEnemyList();
    }
}
