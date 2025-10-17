using System;
using System.Collections.Generic;
using System.Drawing;
using NUnit.Framework;
using UnityEngine;
using Utilities;
using Object = System.Object;

namespace Utilities
{
    /// <summary>
    /// Lightweight-object-pooling where it creates disabled instances
    /// Will get first index[0] if disabled using Get()
    /// else will create new instance
    /// Gotten instances will push itself to last index
    /// Disabled instances will push itself to first index
    /// </summary>
    public static class Pool
    {
      public class GameObj
      {
          private const int _defaultInitialPoolSize = 10;

          private List<GameObject> _objPool;
          private GameObject _referenceObjInstance;
              
          public GameObj(int size, GameObject obj)
          {
              _objPool = new List<GameObject>();
              _referenceObjInstance = obj;
              
              for (int x = 0; x < size; x++)
                  AddNewObjInstance();
          }

          private void AddNewObjInstance() => _objPool.Add(UnityEngine.Object.Instantiate(_referenceObjInstance));
          public GameObj(GameObject obj) : this(_defaultInitialPoolSize, obj) {}
              
          // Gets first index if available, else, create new instance
          public GameObject Get()
          {
              if ()
          }
      }
    }
}

public class Test
{
    private Pool.GameObj _bulletPool;
    
    private void Start()
    {
        _bulletPool = new Pool.GameObj( 10 , new GameObject());
        _bulletPool = new Pool.GameObj( new GameObject());
    }
}
