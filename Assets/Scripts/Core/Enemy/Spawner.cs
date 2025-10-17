using System;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private SpawnManager _spawnManager;
    
    private void Start()
    {
        _spawnManager = SpawnManager.Instance;
        _spawnManager.AddSpawnerToPool(this);
    }

    public void DoSpawnDelay(float delay)
    {
        gameObject.SetActive(true);
        Invoke(nameof(CallSpawnerAndSpawn), delay);
    }

    private void CallSpawnerAndSpawn()
    {
        _spawnManager.SpawnEnemy(transform.position);
        gameObject.SetActive(false);
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Color gColor = Color.magenta;
        gColor.a = 0.5f;
        Gizmos.color = gColor;
        Gizmos.DrawCube(transform.position, transform.localScale);
    }
#endif
}
