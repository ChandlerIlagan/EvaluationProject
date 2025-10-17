using System;
using UnityEngine;

public class PlayerDefaultWeaponController : MonoBehaviour, IPlayerWeaponController
{
    private bool _canShoot;
    
    public void Initialize(InputSystem_Actions inputSystem)
    {
        
    }

    private void Update()
    {
        
    }

    public void EnableWeapons() => _canShoot = true;
    public void DisableWeapons() => _canShoot = false;
}
