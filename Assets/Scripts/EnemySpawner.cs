using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _timeToSpawn = 2f;
    [SerializeField] private SpawnPoint[] _spawners;
    [SerializeField] private EnemyLogic _enemyPrefab;

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), 0, _timeToSpawn);
    }

    private void Spawn()
    {
        int randomIndex = Random.Range(0, _spawners.Length);
        SpawnPoint spawnPoint = _spawners[randomIndex];
        EnemyLogic enemy = Instantiate(_enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
        enemy.Initialize(spawnPoint.Position);
    }
}
