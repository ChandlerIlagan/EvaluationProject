using System;
using UnityEngine;

public class PooledObject : MonoBehaviour
{
    public System.Action<PooledObject> OnDisabled;

    private void OnDisable()
    {
        OnDisabled?.Invoke(this);
    }

    private void OnDestroy() => OnDisabled = null;
}
