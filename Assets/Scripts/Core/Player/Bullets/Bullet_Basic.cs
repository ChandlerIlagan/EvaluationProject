using System;
using System.Collections;
using UnityEngine;

public class Bullet_Basic : MonoBehaviour, IPlayerBullet
{
    private float _speed;
    private Vector2 _direction;
    private Transform _origParent;
    
    public void Initialize(float moveSpeed, Vector2 direction, Transform origParent)
    {
        _origParent = origParent;
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

    private void OnDisable()
    {
        StopAllCoroutines();
        transform.parent = _origParent;
    }
}