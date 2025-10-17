using System;
using System.Collections.Generic;
using UnityEngine;
using Utilities;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _spawnDelay;
    [SerializeField] private float _spawnerCreationTime;
    
    [Header("Dependencies")]
    [SerializeField] private GameObject _basicEnemyPrefab;
    [SerializeField] private GameObject _spawnReferencePrefab;
    
    public static SpawnManager Instance;

    private Pool.GameObj _basicEnemyPool;
    private List<Spawner> _spawnerObjects;
    private float _timeLastSpawned;
    private bool _canSpawn;
    
    private void Awake()
    {
        _spawnerObjects = new List<Spawner>();
        _canSpawn = false;
        Instance = this;
        _basicEnemyPool = new Pool.GameObj(12, _basicEnemyPrefab, transform);
    }

    private void Start()
    {
        GameManager.Instance.OnGameStateChange += OnGameStateChanged;
    }

    private void OnGameStateChanged(GameManager.GameState state)
    {
        if (state == GameManager.GameState.Start)
            _canSpawn = true;
        else
            _canSpawn = false;
    }

    public GameObject AddSpawnerToPool(Spawner spawner)
    {
        spawner.gameObject.SetActive(false);
        
        if (_spawnerObjects.Count > 1)
            _spawnerObjects.Insert(0,spawner);
        else
            _spawnerObjects.Add(spawner);
        
        return spawner.gameObject;
    }

    private Spawner GetRandomAvailableSpawner()
    {
        int index = Random.Range(0, _spawnerObjects.Count);
        
        if (!_spawnerObjects[index].gameObject.activeInHierarchy)
            return _spawnerObjects[index];
        
        return null;
    }

    private void FixedUpdate()
    {
        if (!_canSpawn)
            return;
        
        if (Time.time - _timeLastSpawned >= _spawnDelay)
        {
            _timeLastSpawned = Time.time;
            ActivateIdleSpawner();
        }
    }

    private void ActivateIdleSpawner()
    {
        Spawner freeSpawner = GetRandomAvailableSpawner();

        if (freeSpawner != null)
        {
            freeSpawner.DoSpawnDelay(_spawnerCreationTime);
        }
    }

    public void SpawnEnemy(Vector2 position)
    {
        GameObject spawnedEnemy = _basicEnemyPool.Get();
        spawnedEnemy.GetComponent<EnemyBase>().OnSpawn();
        spawnedEnemy.transform.position = position;
    }
}