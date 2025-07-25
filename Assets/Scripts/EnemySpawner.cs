using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject swarmerPrefab;
    [SerializeField] private float swarmerInterval = 1f;

    private int playerHP = 100;

    void Start()
    {
        StartCoroutine(SpawnEnemyLoop());
    }

    private IEnumerator SpawnEnemyLoop()
    {
        while (playerHP == 100)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(swarmerInterval);
        }
    }

    private void SpawnEnemy()
    {
        Vector3 spawnPosition = transform.position; // vagy ahova szeretnéd
        Instantiate(swarmerPrefab, spawnPosition, quaternion.identity);
    }
}
