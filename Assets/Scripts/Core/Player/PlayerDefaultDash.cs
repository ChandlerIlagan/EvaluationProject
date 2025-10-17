using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDefaultDash : MonoBehaviour , IPlayerDash
{
    [SerializeField] private float _dashSpeedMultiplier = 1.5f;
    [SerializeField] private float _dashDuration = 1.2f;
    
    private bool _canDash = false;
    private float _lastDashTime;
    private InputSystem_Actions _inputSystem;
    private IPlayerMovement _playerMovement;
    
    public void Initialize(InputSystem_Actions inputSystem, IPlayerMovement playerMovement)
    {
        _inputSystem = inputSystem;
        _playerMovement = playerMovement;
        
        _inputSystem.Player.Dash.performed += OnDashPressed;
    }

    private void OnDashPressed(InputAction.CallbackContext obj)
    {
        if (!_canDash)
            return;
        if (Time.time - _lastDashTime < _dashDuration)
            return;

        Dash();
    }

    private void Dash()
    {
        _lastDashTime = Time.time;
        _playerMovement.DashMultiplier = _dashSpeedMultiplier;
        Invoke(nameof(CancelDash), _dashDuration);
    }

    private void CancelDash()
    {
        _playerMovement.DashMultiplier = 1;
    }

    public void EnableDash() => _canDash = true;
    public void DisableDash() => _canDash = false;

    private void OnDisable()
    {
        _inputSystem.Player.Dash.performed -= OnDashPressed;
    }
}
