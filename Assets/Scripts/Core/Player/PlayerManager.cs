using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerManager : MonoBehaviour
{
    [Header("Dependencies-settings")]
    [SerializeField] private PlayerSettingsSO _playerSettings;
    [Header("Dependencies-interfaces")]
    [SerializeField] private MonoBehaviour _playerIMovement;
    [SerializeField] private MonoBehaviour _playerIWeaponController;
    [SerializeField] private MonoBehaviour _playerIDash;
    [Header("Dependencies-scene")]
    [SerializeField] private DeathCone _deathCone;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Animator _spriteAnimator;

    private IPlayerMovement _playerMovement => _playerIMovement as IPlayerMovement;
    private IPlayerWeaponController _playerWeaponController => _playerIWeaponController as IPlayerWeaponController;
    private IPlayerDash _playerDash => _playerIDash as IPlayerDash;
    
    private InputSystem_Actions _inputSystem;
    private Rigidbody2D _playerRigidbody2D;
    private GameManager _gameManager;
    private bool _canTakeDamage;

    public static PlayerManager Instance;

    private void Awake()
    {
        Instance = this;
        _playerRigidbody2D = GetComponent<Rigidbody2D>();
        _inputSystem = new InputSystem_Actions();
        _inputSystem.Enable();
        
        _playerMovement.Initialize(_inputSystem);
        _playerWeaponController.Initialize(_inputSystem, _playerSettings);
        _playerDash.Initialize(_inputSystem, _playerMovement);
    }

    private void Start()
    {
        _gameManager = GameManager.Instance;
        _canTakeDamage = true;
        _playerMovement.EnableMovement();
        _playerWeaponController.EnableWeapons();
        _playerDash.EnableDash();
    }

    private void Update()
    {
        _playerMovement.Move2DRigid(_playerRigidbody2D).WithSpeed(_playerSettings.MovementSpeed);
    }

    private void TakeDamage()
    {
        if (!_canTakeDamage)
            return;

        _canTakeDamage = false;
        _gameManager.Lives--;
        _spriteAnimator.CrossFade("Invulnerable", 0f);
        Invoke(nameof(BecomeVulnerable), _playerSettings.DamageInvulDuration);
        
        if (_gameManager.Lives > 0)
        {
            _deathCone.DoExplosion(transform.position);
        }
        else
        {
            Death();
        }
    }

    private void BecomeVulnerable()
    {
        _canTakeDamage = true;
        _spriteAnimator.CrossFade("Vulnerable", 0f);
    }

    private void Death()
    {
        _spriteRenderer.enabled = false;
        _playerMovement.DisableMovement();
        _playerWeaponController.DisableWeapons();
        _playerDash.DisableDash();
     
        Invoke(nameof(DoGameOverScreen), 1.0f);
    }

    private void DoGameOverScreen() => _gameManager.CurrentGameState = GameManager.GameState.GameOver;
    
    private void OnDestroy()
    {
        _inputSystem.Disable();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {  
        if (other.transform.CompareTag("Enemy"))
        {
            TakeDamage();
        }
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        if (_playerIMovement is null || _playerIMovement is not IPlayerMovement)
            Debug.LogError("[PlayerManager] playerIMovement is not a valid 'IPlayerMovement' interface");
    }
    #endif
}
