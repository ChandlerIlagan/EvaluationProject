using UnityEngine;

[CreateAssetMenu(fileName = "WeaponName_Settings", menuName = "Scriptable Objects/PlayerWeapon")]
public class PlayerWeaponSettingsSO : ScriptableObject
{
    public float ShootForce => _shootForce;
    public float ReloadTime => _reloadTime;
    
    [Header("Settings")]
    [SerializeField] private float _shootForce;
    [SerializeField] private float _reloadTime;
}
