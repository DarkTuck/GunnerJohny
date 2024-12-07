using UnityEngine;
using UnityEngine.Rendering;

public class PickUpScript : MonoBehaviour
{
    [SerializeField] private Transform playerPossiton;
    [SerializeField] private float pickDistance;
    public bool CheckDistance()
    {
        if (Vector3.Distance(transform.position, playerPossiton.position) <= pickDistance)
        {
            return true;
        }
        return false;
    }
}
