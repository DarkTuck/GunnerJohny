using UnityEngine;
using NaughtyAttributes;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon/Weapon")]
public class Weapon : ScriptableObject
{
    public int damage;
    public WeaponType weaponType;
    public float fireRate;
    [SerializeField] bool isProjectile;
    public float equipTime;
    [FormerlySerializedAs("ammunitonType")] public AmmunitonType ammoType;
    public AudioClip shoot;
    [ShowIf("isProjectile")]public GameObject projectile;
    [ShowIf("isProjectile")]public float projectileSpeed;
    public Sprite weaponModel;
}

public enum WeaponType
{
    pistol,
    shotgun,
    rocketgun,
    plasma,
    bfg,
    
}
