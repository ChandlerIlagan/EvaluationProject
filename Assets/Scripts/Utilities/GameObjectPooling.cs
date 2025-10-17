using System;
using System.Collections.Generic;
using System.Drawing;
using NUnit.Framework;
using UnityEngine;
using Utilities;
using Object = System.Object;

namespace Utilities
{
    
    public static class Pool
    {
      public class GameObj
      {
          private const int _defaultInitialPoolSize = 10;

          private List<GameObject> _objPool;
          public GameObj(int size, GameObject obj)
          {
              _objPool = new List<GameObject>();
              
              for (int x = 0; x < size; x++)
                  _objPool.Add(UnityEngine.Object.Instantiate(obj));
          }

          public GameObj(GameObject obj) : this(_defaultInitialPoolSize, obj) {}
              
          public GameObject Get(int index) => _objPool[index];
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
