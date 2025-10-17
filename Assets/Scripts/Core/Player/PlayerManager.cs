using System;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerSettingsSO _playerSettings;
    [SerializeField] private MonoBehaviour _playerIMovement;

    private IPlayerMovement _playerMovement => _playerIMovement as IPlayerMovement;
    private void Start()
    {
        _playerMovement.EnableMovement();
    }

    private void Update()
    {
        _playerMovement.WithSpeed(_playerSettings.MovementSpeed).MoveUpdate();
    }
    
    #if UNITY_EDITOR
    private void OnValidate()
    {
        if (_playerIMovement is null || _playerIMovement is not IPlayerMovement)
            Debug.LogError("[PlayerManager] playerIMovement is not a valid 'IPlayerMovement' interface");
    }
    #endif
}
