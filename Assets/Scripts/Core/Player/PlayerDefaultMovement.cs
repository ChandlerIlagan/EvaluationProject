using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDefaultMovement : MonoBehaviour, IPlayerMovement
{
    public bool CanMove => _canMove;

    private bool _canMove;
    private bool _isMoving;
    private float _moveSpeed = 0;
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
        _isMoving = true;
    }
    private void OnMoveReleased(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        if (input == Vector2.zero)
            _isMoving = false;
    }

    public IPlayerMovement Move2DRigid(Rigidbody2D gameObject)
    {
        if (!_canMove)
            return this;

        
        
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