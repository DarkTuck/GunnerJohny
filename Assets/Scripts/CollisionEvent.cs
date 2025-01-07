using System;
using UnityEngine;
using UnityEngine.Events;

public class CollisionEvent : MonoBehaviour
{
    [SerializeField] UnityEvent onCollision;
    

    private void OnCollisionEnter(Collision other)
    {
        onCollision.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        onCollision.Invoke();
    }
}
