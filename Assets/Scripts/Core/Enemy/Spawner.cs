using System;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private void Start()
    {
        SpawnManager.Instance.AddSpawnerToPool(gameObject);
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Color gColor = Color.magenta;
        gColor.a = 0.5f;
        Gizmos.color = gColor;
        Gizmos.DrawCube(transform.position, transform.localScale);
    }
#endif
}
