using UnityEngine;

public interface IPlayerMovement
{
    public bool CanMove { get; }
    IPlayerMovement MoveUpdate();
    IPlayerMovement WithSpeed(float speed);
    public void EnableMovement();
    public void DisableMovement();
}
