using UnityEngine;

public interface IPlayerWeaponController
{
    public PlayerWeaponSettingsSO CurrentWeaponSettings { get; }
    public void Initialize(InputSystem_Actions inputSystem, PlayerSettingsSO playerSettings);
    public void ChangeWeapon(PlayerWeaponSettingsSO weaponSetting);
    public void EnableWeapons();
    public void DisableWeapons();
}
