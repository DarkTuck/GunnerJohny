using System.Collections;
using UnityEngine;

public class CloseAttack : MonoBehaviour
{
   // [SerializeField] private float range=0.5f;
    //[SerializeField] private int damage=5; //Temporary
    //[SerializeField] float closeAtackCooldown=1f;
    [SerializeField] Animator animator;
    [SerializeField] private EnemyInt _enemyInt;
    Transform thisTransform;
    bool isAttacking;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        thisTransform = transform;
    }
    void FixedUpdate()
    {
        if (Vector3.Distance(thisTransform.position, PlayerSingleton._player.position) < _enemyInt.range&&!isAttacking)
        {
            StartCoroutine(Attack());
        }
    }
    
    IEnumerator Attack()
    {
        isAttacking = true;
        Debug.Log("Starting");
        yield return new WaitForSeconds(_enemyInt.cooldown);
        Debug.Log("Ending");
        PlayerSingleton._damageable.Damage(_enemyInt.damage);
        isAttacking = false;
        animator.SetTrigger("shoot");

    }
    
}
