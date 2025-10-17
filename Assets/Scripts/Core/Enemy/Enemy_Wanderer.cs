using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_Wanderer : EnemyBase
{
    private Transform _target;
    private Rigidbody2D _body;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _target = PlayerManager.Instance.transform;
        OnSpawn();
    }

    private void FixedUpdate()
    {
        if (!gameObject.activeInHierarchy)
            return;
        
        Vector2 dir = (_target.position - transform.position).normalized;
        _body.MovePosition(_body.position + dir * (_moveSpeed * Time.fixedDeltaTime));
    }

    public override void OnSpawn()
    {
        
    }
}
