using UnityEngine;
using UnityEngine.AI;

public class SetTarget : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(PlayerSingleton._player.transform.position);    
    }
}
