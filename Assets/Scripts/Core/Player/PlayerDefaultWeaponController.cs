using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDefaultWeaponController : MonoBehaviour, IPlayerWeaponController
{
    [SerializeField] private PlayerWeaponSettingsSO _initialWeaponSetting;
    
    private bool _canShoot;
    private InputSystem_Actions _inputSystem;
    private PlayerWeaponSettingsSO _currentWeaponSettings;
    
    public void Initialize(InputSystem_Actions inputSystem, PlayerSettingsSO playerSettings)
    {
        ChangeWeapon(_initialWeaponSetting);
        
        _inputSystem = inputSystem;
        _inputSystem.Player.Shoot.performed += OnShoot;
    }

    private void OnShoot(InputAction.CallbackContext obj)
    {
        
    }

    private void Update()
    {
        
    }

    public void ChangeWeapon(PlayerWeaponSettingsSO weaponSetting)
    {
        _currentWeaponSettings = weaponSetting;
    }

    public void EnableWeapons() => _canShoot = true;
    public void DisableWeapons() => _canShoot = false;

    private void OnDisable()
    {
        _inputSystem.Player.Shoot.performed -= OnShoot;
    }
}
