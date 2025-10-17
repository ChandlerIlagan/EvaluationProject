using UnityEngine;

public interface IPlayerDash
{
    public void Initialize(InputSystem_Actions inputSystem, IPlayerMovement playerMovement);
    public void EnableDash();
    public void DisableDash();
}
