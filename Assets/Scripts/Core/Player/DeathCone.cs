using System;
using UnityEngine;

public class DeathCone : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void DoExplosion(Vector2 position)
    {
        transform.position = position;
        gameObject.SetActive(true);
        _animator.CrossFade("DeathConeAnim", 0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyBase>().TakeDamage(10);
        }
    }

    public void OnExplosionFinish()
    {
        gameObject.SetActive(false);
    }
}
