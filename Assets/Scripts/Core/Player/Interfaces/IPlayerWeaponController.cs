using UnityEngine;

public interface IPlayerWeaponController
{
    public void Initialize(InputSystem_Actions inputSystem, PlayerSettingsSO playerSettings);
    public void EnableWeapons();
    public void DisableWeapons();
}
