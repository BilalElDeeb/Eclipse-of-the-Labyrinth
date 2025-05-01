using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnController : MonoBehaviour
{
    public List<GameObject> enemyPrefabs = new List<GameObject>();
    public GameObject spawnPointParent;
    private List<Transform> spawnPoints;
    private int numberOfEnemies;
    private bool spawned = false;

    private void Awake()
    {
        spawnPoints = spawnPointParent.GetComponentsInChildren<Transform>().ToList().Skip(1).ToList();
        numberOfEnemies = Random.Range(1, 10);
    }

    void spawnEnemy(Transform spawnPoint, GameObject enemyPrefab)
    {
        Instantiate(enemyPrefab, spawnPoint.position, quaternion.identity);
    }

    IEnumerator spawnEnemies()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            for (int j = 0; j < spawnPoints.Count; j++)
            {
                spawnEnemy(spawnPoints[j], enemyPrefabs[(Random.Range(0, enemyPrefabs.Count))]);
            }
            yield return new WaitForSeconds(2f);
        }
    }
    
    void OnTriggerEnter2D (Collider2D target)
    {
        if (target.tag == "Player" && !spawned)
        {
            spawned = true;
            StartCoroutine(spawnEnemies());
        }
    }
}
