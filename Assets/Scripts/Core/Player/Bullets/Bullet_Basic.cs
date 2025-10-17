using System;
using System.Collections;
using UnityEngine;

public class Bullet_Basic : MonoBehaviour, IPlayerBullet
{
    private float _speed;
    private Vector2 _direction;
    
    public void Initialize(float moveSpeed, Vector2 direction)
    {
        _speed = moveSpeed;
        _direction = direction;
    }

    private IEnumerator BulletBehavior()
    {
        while (true)
        {
            transform.Translate(_direction * _speed * Time.deltaTime, Space.World);
            yield return null;
        }
    }

    private void OnDisable() => StopAllCoroutines();
}