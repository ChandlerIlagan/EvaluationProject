using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using Utilities;

public class PlayerDefaultWeaponController : MonoBehaviour, IPlayerWeaponController
{
    private const int _initialBulletCount = 30;
    
    [SerializeField] private PlayerWeaponSettingsSO _initialWeaponSetting;
    [SerializeField] private GameObject _bulletPrefab;
    
    private bool _canShoot;
    private InputSystem_Actions _inputSystem;
    private PlayerWeaponSettingsSO _currentWeaponSettings;
    private Pool.GameObj _bulletPool;
    private Coroutine _shootingRoutine;
    private Vector2 _currentAimDirection = Vector2.right;
    
    public void Initialize(InputSystem_Actions inputSystem, PlayerSettingsSO playerSettings)
    {
        _shootingRoutine = null;
        _bulletPool = new Pool.GameObj(_initialBulletCount ,_bulletPrefab, transform);
        ChangeWeapon(_initialWeaponSetting);
        
        _inputSystem = inputSystem;
        _inputSystem.Player.Shoot.performed += OnShootStart;
        _inputSystem.Player.Shoot.canceled += OnShootStop;
    }

    private void OnShootStart(InputAction.CallbackContext obj)
    {
        if (_shootingRoutine != null)
            StopCoroutine(_shootingRoutine);
        
        _shootingRoutine = StartCoroutine(ShootingBehavior());
    }
    
    private void OnShootStop(InputAction.CallbackContext obj)
    {
        if (_shootingRoutine != null)
            StopCoroutine(_shootingRoutine);
        
        _shootingRoutine = null;
    }

    private IEnumerator ShootingBehavior()
    {
        float timeLastShot = Time.time;
        
        while (_canShoot)
        {
            if (Time.time - timeLastShot >= _currentWeaponSettings.ReloadTime)
            {
                timeLastShot = Time.time;
                Shoot();
            }
            
            yield return null;
        }
    }

    private void Shoot()
    {
        GameObject bullet = _bulletPool.Get();
        bullet.transform.position = transform.position;
        bullet.GetComponent<IPlayerBullet>().Initialize(_currentWeaponSettings.ShootForce , _currentAimDirection, transform);
    }

    public void ChangeWeapon(PlayerWeaponSettingsSO weaponSetting)
    {
        _currentWeaponSettings = weaponSetting;
    }

    public void EnableWeapons() => _canShoot = true;
    public void DisableWeapons() => _canShoot = false;

    private void OnDisable()
    {
        _inputSystem.Player.Shoot.performed -= OnShootStart;
        _inputSystem.Player.Shoot.canceled -= OnShootStop;
    }
}
