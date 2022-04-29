using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _timeToSpawn = 2f;
    [SerializeField] private SpawnPoint[] _spawners;
    [SerializeField] private EnemyLogic enemyPrefab;

    private void Spawn()
    {
        int randomIndex = Random.Range(0, _spawners.Length);
        SpawnPoint spawnPoint = _spawners[randomIndex];
        EnemyLogic enemy = Instantiate(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
        enemy.Initialize(spawnPoint.Position);
    }

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), 0, _timeToSpawn);
    }
}
