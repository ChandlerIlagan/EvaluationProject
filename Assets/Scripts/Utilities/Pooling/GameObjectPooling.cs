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
    /// Highly recommended to initialize on Awake()
    ///     > Will get first index[0] if disabled using Get()
    ///     > else will create new instance
    ///     > Gotten instances will push itself to last index
    ///     > Disabled instances will push itself to first index
    /// </summary>
    public static class Pool
    {
      public class GameObj
      {
          private const int _defaultInitialPoolSize = 10;

          private List<GameObject> _objPool;
          private GameObject _referenceObjInstance;
              
          public GameObj(int size, GameObject obj, Transform parent)
          {
              _objPool = new List<GameObject>();
              _referenceObjInstance = obj;
              
              for (int x = 0; x < size; x++)
              {
                  GameObject newObj = AddNewObjInstance();
                  
                  if (parent != null)
                      newObj.transform.parent = parent;
              }
          }
          
          public GameObj(GameObject obj, Transform parent) : this(_defaultInitialPoolSize, obj, parent) {}
          public GameObj(GameObject obj) : this(_defaultInitialPoolSize, obj, null) {}

          private GameObject AddNewObjInstance()
          {
              GameObject newObj = UnityEngine.Object.Instantiate(_referenceObjInstance);
              _objPool.Add(newObj);
              return newObj;
          }
              
          public GameObject Get(bool isActiveOnGet)
          {
              GameObject objectToReturn;
              
              if (!_objPool[0].activeInHierarchy)
                  objectToReturn = _objPool[0];
              else
                  objectToReturn = AddNewObjInstance();

              objectToReturn.SetActive(isActiveOnGet);
              return objectToReturn;
          }

          public GameObject Get() => Get(true);
      }
    }
}