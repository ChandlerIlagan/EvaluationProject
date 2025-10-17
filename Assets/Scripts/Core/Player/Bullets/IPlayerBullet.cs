using System.Collections;
using UnityEngine;

public interface IPlayerBullet
{
    public void Initialize(float moveSpeed, Vector2 direction, Transform origParent);
}
