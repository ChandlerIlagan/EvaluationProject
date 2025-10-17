using UnityEngine;

public class PooledObject : MonoBehaviour
{
    public System.Action<GameObject> OnDisabled;
    private void OnDisable() => OnDisabled?.Invoke(gameObject);
    private void OnDestroy() => OnDisabled = null;
}
