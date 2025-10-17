using System;
using UnityEngine;
using Utilities;

public class SpawnManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _spawnDelay;
    
    [Header("Dependencies")]
    [SerializeField] private GameObject _spawnReferencePrefab;
    private Pool.GameObj _spawnPool;
    
    public static SpawnManager Instance;

    private void Awake()
    {
        Instance = this;
        _spawnPool = new Pool.GameObj(0, _spawnReferencePrefab, transform);
    }

    public GameObject AddSpawnerToPool(GameObject obj)
    {
        _spawnPool.Add(gameObject);
        Debug.Log($"[SpawnManager] added new spawner. Total[ {_spawnPool.Count} ]");
        return obj;
    }
}