using UnityEngine;

public interface IPlayerWeaponController
{
    public void Initialize(InputSystem_Actions inputSystem);
    public void EnableWeapons();
    public void DisableWeapons();
}
