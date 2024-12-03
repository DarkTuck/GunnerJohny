using UnityEngine;
using NaughtyAttributes;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon/Weapon")]
public class Weapon : ScriptableObject
{
    public int damage;
    public int ammoCount;
    //[HideInInspector]public int currentAmmo;
    public float fireRate;
    public bool isProjectile;
    public float reloadTime;
    public float equipTime;
    public AmmunitonType ammunitonType;
    [ShowIf("isProjectile")]public GameObject projectile;
    [ShowIf("isProjectile")]public float projectileSpeed;
    public Sprite weponModel;
}
