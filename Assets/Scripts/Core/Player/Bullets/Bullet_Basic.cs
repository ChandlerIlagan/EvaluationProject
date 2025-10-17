using System;
using System.Collections;
using UnityEngine;

public class Bullet_Basic : MonoBehaviour, IPlayerBullet
{
    private float _speed;
    private Vector2 _direction;
    private Transform _origParent;
    private bool _isMoving;
    
    public void Initialize(float moveSpeed, Vector2 direction, Transform origParent)
    {
        transform.parent = null;
        
        _origParent = origParent;
        _speed = moveSpeed;
        _direction = direction;

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

    private void OnDisable()
    {
        if (_isMoving)
        {
            _isMoving = false;
            StopAllCoroutines();
            
            if (!_origParent.gameObject.activeInHierarchy)   // fixes error throws when stopping unity editor
                return;
            
            transform.SetParent(_origParent);
            transform.SetAsFirstSibling();
        }
    }
}