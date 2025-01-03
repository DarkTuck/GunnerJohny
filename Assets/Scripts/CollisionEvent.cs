using UnityEngine;
using UnityEngine.Events;

public class CollisionEvent : MonoBehaviour
{
    [SerializeField] UnityEvent onCollision;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void onCollisionEnter()
    {
        onCollision.Invoke();
    }

    void onTriggerEnter()
    {
        onCollision.Invoke();
    }
}
