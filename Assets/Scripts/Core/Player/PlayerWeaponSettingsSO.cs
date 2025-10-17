using UnityEngine;

[CreateAssetMenu(fileName = "WeaponName_Settings", menuName = "Scriptable Objects/PlayerWeapon")]
public class PlayerWeaponSettingsSO : ScriptableObject
{
    public GameObject BulletPrefab => _bulletPrefab;
    public float ShootForce => _shootForce;
    public float ShootSpread => _shootSpread;
    public int ShootAmount => _shootAmount;
    
    [Header("Dependencies")]
    [SerializeField] private GameObject _bulletPrefab;
    [Header("Settings")]
    [SerializeField] private float _shootForce;
    [SerializeField] private int _shootAmount;
    [SerializeField] private float _shootSpread;
}
