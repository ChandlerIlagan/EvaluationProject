using System;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    internal int _hp;
    internal float _moveSpeed;
    internal int _scoreGiven;

    public abstract void OnSpawn();
    
    public void TakeDamage(int damage)
    {
        _hp -= damage;
        
        if (_hp <= 0)
            Death();
    }

    private void Death()
    {
        GameManager.Instance.Score += _scoreGiven;
        FXManager.Instance.DoFX(FXManager.FXList.EnemyExplosion , transform.position);
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
