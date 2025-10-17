using System;
using UnityEngine;
using Utilities;

public class FXManager : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private GameObject _explosionPrefab;
    [SerializeField] private Transform _explosionParent;
    
    private Pool.GameObj _enemyExplosionPool;
    
    public static FXManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _enemyExplosionPool = new Pool.GameObj(30, _explosionPrefab, _explosionParent);
    }

    public void DoFX(FXList fx, Vector2 position)
    {
        switch (fx)
        {
            case FXList.EnemyExplosion:
                GameObject explosion = _enemyExplosionPool.Get();
                explosion.transform.position = position;
                explosion.GetComponent<ParticleSystem>().Play();
                break;
        }
    }
    
    public enum FXList
    {
        EnemyExplosion
    }
}
