using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDefaultWeaponController : MonoBehaviour, IPlayerWeaponController
{
    private bool _canShoot;
    private float _shootForce;
    private InputSystem_Actions _inputSystem;
    
    public void Initialize(InputSystem_Actions inputSystem, PlayerSettingsSO playerSettings)
    {
        _shootForce = playerSettings.ShootForce;
        
        _inputSystem = inputSystem;
        _inputSystem.Player.Shoot.performed += OnShoot;
    }

    private void OnShoot(InputAction.CallbackContext obj)
    {
        
    }

    private void Update()
    {
        
    }

    public void EnableWeapons() => _canShoot = true;
    public void DisableWeapons() => _canShoot = false;

    private void OnDisable()
    {
        _inputSystem.Player.Shoot.performed -= OnShoot;
    }
}
