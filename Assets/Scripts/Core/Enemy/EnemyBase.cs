using System;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private int _hp;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private int _scoreGiven;

    public Action<int> OnDeath;
    
    public void TakeDamage(int damage)
    {
        _hp -= damage;
        
        if (_hp <= 0)
            Death();
    }

    private void Death()
    {
        OnDeath?.Invoke(_scoreGiven);
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        OnDeath = null;
    }
}
