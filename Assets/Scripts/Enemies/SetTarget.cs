using UnityEngine;
using UnityEngine.AI;

public class SetTarget : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    //[SerializeField] float targetDistance;
    [SerializeField] Animator animator;
    [SerializeField] EnemyInt _enemyInt;
    private Transform objectTransform;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objectTransform = transform;
        agent.speed = _enemyInt.speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(objectTransform.position, agent.destination) <= _enemyInt.targetDistance)
        {
            agent.SetDestination(PlayerSingleton._player.transform.position);
            animator.SetBool("walking", true);
        }
        else
        {
            agent.SetDestination(objectTransform.position);
            animator.SetBool("walking", false);
        }
    }

}
