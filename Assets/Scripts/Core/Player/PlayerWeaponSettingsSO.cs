using UnityEngine;

[CreateAssetMenu(fileName = "WeaponName_Settings", menuName = "Scriptable Objects/PlayerWeapon")]
public class PlayerWeaponSettingsSO : ScriptableObject
{
    public GameObject BulletPrefab => _bulletPrefab;
    public float ShootSpread => _shootSpread;
    
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _shootSpread;
}
