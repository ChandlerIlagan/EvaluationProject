using UnityEngine;

public interface IPlayerMovement
{
    public bool CanMove { get; }
    IPlayerMovement Move2DRigid(Rigidbody2D body);
    IPlayerMovement WithSpeed(float speed);
    public void EnableMovement();
    public void DisableMovement();
    public void Initialize(InputSystem_Actions inputSystem);
}
