using System;
using UnityEngine;
using Utilities;

public class SpawnManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _spawnDelay;
    
    [Header("Dependencies")]
    [SerializeField] private GameObject _spawnReferencePrefab;
    
    public static SpawnManager Instance;
    
    private Pool.GameObj _spawnPool;
    private float _timeLastSpawned;
    
    private void Awake()
    {
        Instance = this;
        _spawnPool = new Pool.GameObj(0, _spawnReferencePrefab, transform);
    }

    public GameObject AddSpawnerToPool(GameObject obj)
    {
        _spawnPool.Add(gameObject);
        return obj;
    }

    private void FixedUpdate()
    {
        if (Time.time - _timeLastSpawned >= _spawnDelay)
        {
            SpawnEnemy();
        }
    }

    public void SpawnEnemy()
    {
        _timeLastSpawned = Time.time;
    }
}