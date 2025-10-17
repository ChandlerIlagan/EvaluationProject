using UnityEngine;

public class PlayerDefaultMovement : MonoBehaviour, IPlayerMovement
{
    public bool CanMove => _canMove;

    private bool _canMove;
    private float _moveSpeed = 0;
    
    public IPlayerMovement MoveUpdate()
    {
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
