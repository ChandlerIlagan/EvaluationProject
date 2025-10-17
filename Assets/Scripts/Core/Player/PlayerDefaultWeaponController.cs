using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDefaultWeaponController : MonoBehaviour, IPlayerWeaponController
{
    private bool _canShoot;
    
    public void Initialize(InputSystem_Actions inputSystem)
    {
        inputSystem.Player.Shoot.performed += OnShoot;
    }

    private void OnShoot(InputAction.CallbackContext obj)
    {
        
    }

    private void Update()
    {
        
    }

    public void EnableWeapons() => _canShoot = true;
    public void DisableWeapons() => _canShoot = false;
}
