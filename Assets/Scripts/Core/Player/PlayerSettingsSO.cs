using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSetting", menuName = "Scriptable Objects/Player Settings")]
public class PlayerSettingsSO : ScriptableObject
{
    public float MovementSpeed => _movementSpeed;
    public float ShootForce => _shootForce;
    
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _shootForce;
}
