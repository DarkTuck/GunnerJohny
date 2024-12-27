using UnityEngine;
using UnityEngine.AI;

public class SetTarget : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] float targetDistance;
    private Transform objectTransform;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objectTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(objectTransform.position, agent.destination) <= targetDistance)
        {
            agent.SetDestination(PlayerSingleton._player.transform.position);
        }
        else
        {
            agent.SetDestination(objectTransform.position);
        }
    }

}
