using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _timeToSpawn = 2f;
    [SerializeField] private Spawner[] _spawners;
    [SerializeField] private EnemyController enemyPrefab;

    private void SpawnEnemy()
    {
        int randomIndex = Random.Range(0, _spawners.Length);
        Spawner spawnPoint = _spawners[randomIndex];
        EnemyController enemy = Instantiate(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
        enemy.Initialize(spawnPoint.Position);
    }

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 0, _timeToSpawn);
    }
}
