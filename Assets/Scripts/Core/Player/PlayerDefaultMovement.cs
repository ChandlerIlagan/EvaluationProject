    using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDefaultMovement : MonoBehaviour, IPlayerMovement
{
    [Header("Dependencies")]
    [SerializeField] private Transform _spriteTransform;
    
    public bool CanMove => _canMove;
    public float DashMultiplier { get; set; }

    private bool _canMove;
    private bool _isMoving;
    private float _moveSpeed = 0;
    private Vector2 _movementOffset;
    private InputSystem_Actions _inputSystem;
    private GameManager _gameManager;
    
    public void Initialize(InputSystem_Actions inputSystem)
    {
        DashMultiplier = 1;
        _inputSystem = inputSystem;
        _gameManager = GameManager.Instance;

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
        if (!_canMove && _gameManager.CurrentGameState != GameManager.GameState.Start)
            return this;

        body.linearVelocity = _movementOffset * _moveSpeed * DashMultiplier;
        if (_movementOffset.sqrMagnitude > 0.001f)
        {
            float angle = Mathf.Atan2(_movementOffset.y, _movementOffset.x) * Mathf.Rad2Deg;
            _spriteTransform.localEulerAngles = new Vector3(0f, 0f, angle - 90f);
        }
        
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