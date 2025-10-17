using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDefaultMovement : MonoBehaviour, IPlayerMovement
{
    public bool CanMove => _canMove;

    private bool _canMove;
    private bool _isMoving;
    private float _moveSpeed = 0;
    private Vector2 _movementOffset;
    private InputSystem_Actions _inputSystem;
    
    public void Initialize(InputSystem_Actions inputSystem)
    {
        _inputSystem = inputSystem;
        _inputSystem.Enable();

        _inputSystem.Player.Move.performed += OnMovePressed;
        _inputSystem.Player.Move.canceled += OnMoveReleased;
    }

    private void OnMovePressed(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        _isMoving = true;
        
        _movementOffset = input;
    }
    private void OnMoveReleased(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        if (input == Vector2.zero)
            _isMoving = false;
        
        _movementOffset = input;
    }

    public IPlayerMovement Move2DRigid(Rigidbody2D body)
    {
        if (!_canMove)
            return this;

        body.linearVelocity = _movementOffset * _moveSpeed;
        
        return this;
    }

    public IPlayerMovement WithSpeed(float speed)
    {
        _moveSpeed = speed;
        return this;
    }

    public void DisableMovement() => _canMove = false;
    public void EnableMovement() => _canMove = true;

    private void OnDisable()
    {
        _inputSystem.Player.Move.performed -= OnMovePressed;
        _inputSystem.Player.Move.canceled -= OnMoveReleased;
    }
}

//public struct Input