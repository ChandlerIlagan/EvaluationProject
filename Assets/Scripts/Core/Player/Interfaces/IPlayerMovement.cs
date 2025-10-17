using UnityEngine;

public interface IPlayerMovement
{
    public bool CanMove { get; }
    public float DashMultiplier { get; set; }
    IPlayerMovement Move2DRigid(Rigidbody2D body);
    IPlayerMovement WithSpeed(float speed);
    public void EnableMovement();
    public void DisableMovement();
    public void Initialize(InputSystem_Actions inputSystem);
}
