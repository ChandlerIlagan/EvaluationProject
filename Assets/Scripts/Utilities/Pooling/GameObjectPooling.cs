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
    /// GameObject & Parent.Transform = REQUIRED, size of pool = OPTIONAL
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
          private Transform _referenceParentTransform;
              
          public GameObj(int size, GameObject obj, Transform parent)
          {
              _objPool = new List<GameObject>();
              _referenceObjInstance = obj;
              _referenceParentTransform = parent;
              
              for (int x = 0; x < size; x++)
              {
                  GameObject newObj = AddNewObjInstance();
                  newObj.SetActive(false);
                  
                  if (parent != null)
                      newObj.transform.SetParent(parent);
              }
          }
          
          public GameObj(GameObject obj, Transform parent) : this(_defaultInitialPoolSize, obj, parent) {}

          public GameObject Get(bool isActiveOnGet)
          {
              GameObject objectToReturn = null;

              for (int i = 0; i < _objPool.Count; i++)
              {
                  if (!_objPool[i].activeInHierarchy)
                  {
                      objectToReturn = _objPool[i];
                      break;
                  }
              }

              if (objectToReturn == null)
                  objectToReturn = AddNewObjInstance();

              objectToReturn.SetActive(isActiveOnGet);
              objectToReturn.transform.SetAsLastSibling();

              return objectToReturn;
          }

          public GameObject Get() => Get(true);
          
          private GameObject AddNewObjInstance()
          {
              GameObject newObj = UnityEngine.Object.Instantiate(_referenceObjInstance, _referenceParentTransform);
              PooledObject pooledObject = newObj.AddComponent<PooledObject>();
              pooledObject.OnDisabled += OnObjectInPoolDisabled;
              _objPool.Add(newObj);
              return newObj;
          }

          private void OnObjectInPoolDisabled(GameObject obj)
          {
              if (!obj.transform.parent.gameObject.activeInHierarchy)   // fixes error throws when stopping unity editor
                  return;
              
              obj.transform.SetAsFirstSibling();
          }
      }
      
    }
}