using System;
using UnityEngine;
using Utilities;

public class TestScript : MonoBehaviour
{
    [SerializeField] private GameObject _prefabObj;

    private Pool.GameObj _testObjPool;
    private void Start()
    {
        _testObjPool = new Pool.GameObj(3, _prefabObj, transform);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            _testObjPool.Get();
        }
    }
}
