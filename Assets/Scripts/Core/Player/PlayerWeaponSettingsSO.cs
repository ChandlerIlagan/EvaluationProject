using UnityEngine;

[CreateAssetMenu(fileName = "WeaponName_Settings", menuName = "Scriptable Objects/PlayerWeapon")]
public class PlayerWeaponSettingsSO : ScriptableObject
{
    public float ShootForce => _shootForce;
    public float ShootSpread => _shootSpread;
    public float ReloadTime => _reloadTime;
    public int ShootAmount => _shootAmount;
    
    [Header("Settings")]
    [SerializeField] private float _shootForce;
    [SerializeField] private int _shootAmount;
    [SerializeField] private float _shootSpread;
    [SerializeField] private float _reloadTime;
}
