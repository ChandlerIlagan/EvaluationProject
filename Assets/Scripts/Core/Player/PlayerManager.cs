using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerSettingsSO _playerSettings;
    [SerializeField] private MonoBehaviour _playerIMovement;
    [SerializeField] private MonoBehaviour _playerIWeaponController;

    private IPlayerMovement _playerMovement => _playerIMovement as IPlayerMovement;
    private IPlayerWeaponController _playerWeaponController => _playerIWeaponController as IPlayerWeaponController;
    
    private InputSystem_Actions _inputSystem;
    private Rigidbody2D _playerRigidbody2D;

    private void Awake()
    {
        _playerRigidbody2D = GetComponent<Rigidbody2D>();
        _inputSystem = new InputSystem_Actions();
        _inputSystem.Enable();
        
        _playerMovement.Initialize(_inputSystem);
        _playerWeaponController.Initialize(_inputSystem, _playerSettings);
    }

    private void Start()
    {
        _playerMovement.EnableMovement();
        _playerWeaponController.EnableWeapons();
    }

    private void Update()
    {
        _playerMovement.Move2DRigid(_playerRigidbody2D).WithSpeed(_playerSettings.MovementSpeed);
    }
    
    private void OnDestroy()
    {
        _inputSystem.Disable();
    }
    
    #if UNITY_EDITOR
    private void OnValidate()
    {
        if (_playerIMovement is null || _playerIMovement is not IPlayerMovement)
            Debug.LogError("[PlayerManager] playerIMovement is not a valid 'IPlayerMovement' interface");
    }
    #endif
}
