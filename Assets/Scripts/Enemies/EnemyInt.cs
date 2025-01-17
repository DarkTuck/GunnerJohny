using UnityEngine;

[CreateAssetMenu(fileName = "EnemyInt", menuName = "Enemy/EnemyInt")]
public class EnemyInt : ScriptableObject
{
    public int health;
    public int damage;
    public float range, cooldown,targetDistance,speed;
    
}
