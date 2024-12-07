using UnityEngine;
using UnityEngine.Rendering;

public class PickUpScript : MonoBehaviour
{
    [SerializeField] private Transform playerPossiton;
    public bool CheckDistance(float Distance)
    {
        if (Vector3.Distance(transform.position, playerPossiton.position) <= Distance)
        {
            return true;
        }
        return false;
    }
}
