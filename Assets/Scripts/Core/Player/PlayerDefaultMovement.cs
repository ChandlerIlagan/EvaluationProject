using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDefaultMovement : MonoBehaviour, IPlayerMovement
{
    public bool CanMove => _canMove;

    private bool _canMove;
    private float _moveSpeed = 0;
    
    public void Initialize(InputSystem_Actions inputSystem)
    {
        inputSystem.Enable();
        
    }

    public IPlayerMovement MoveUpdate()
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
}

//public struct Input