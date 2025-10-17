using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_Wanderer : EnemyBase
{
    private Transform _target;
    private Rigidbody2D _body;

    [SerializeField] private List<Level> _levels;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _target = PlayerManager.Instance.transform;
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
        int lvl = GameManager.Instance.Level - 1;

        _moveSpeed = _levels[lvl].SpawnSpeed;
        _hp = _levels[lvl].SpawnHP;
        _scoreGiven = _levels[lvl].ScoreGiven;
        GetComponent<SpriteRenderer>().color = _levels[lvl].SpawnColor;
    }
    
    [System.Serializable]
    private struct Level
    {
        public int SpawnHP;
        public float SpawnSpeed;
        public int ScoreGiven;
        public Color SpawnColor;
    }
}
