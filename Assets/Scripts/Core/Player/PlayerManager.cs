using System;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private IPlayerMovement _playerMovement;

    private void Start()
    {
        _playerMovement.EnableMovement();
    }

    private void Update()
    {
        _playerMovement.WithSpeed(1).MoveUpdate();
    }
}
