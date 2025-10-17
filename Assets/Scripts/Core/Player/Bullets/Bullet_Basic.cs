using System;
using System.Collections;
using UnityEngine;

public class Bullet_Basic : MonoBehaviour, IPlayerBullet
{
    private float _speed;
    private Vector2 _direction;
    private Transform _origParent;
    private bool _isMoving;
    
    public void Initialize(float moveSpeed, Vector2 rawDirection, Transform origParent)
    {
        transform.parent = null;
        float angle = Mathf.Atan2(rawDirection.y, rawDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);
        
        _origParent = origParent;
        _speed = moveSpeed;
        _direction = rawDirection.normalized;

        StartCoroutine(BulletBehavior());
    }

    private IEnumerator BulletBehavior()
    {
        _isMoving = true;
        
        while (true)
        {
            transform.Translate(_direction * _speed * Time.deltaTime, Space.World);
            yield return null;
        }
    }

    private void OnBecameInvisible()
    {
        if (gameObject.activeInHierarchy)
            CollisionDisable();
    }

    private void CollisionDisable()
    {
        if (_isMoving)
        {
            _isMoving = false;
            StopAllCoroutines();
            
            transform.SetParent(_origParent);
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyBase>().TakeDamage(1);
            CollisionDisable();
        }
    }
}