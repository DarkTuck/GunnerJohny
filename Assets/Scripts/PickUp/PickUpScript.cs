using UnityEngine;
public class PickUpScript : MonoBehaviour
{
    Transform playerPosition,pickUpTransform;
    [SerializeField] private float pickDistance;
    void OnEnable()
    {
        playerPosition = PlayerSingleton._player.transform;
        pickUpTransform= transform;
    }
    

    protected bool CheckDistance()
    {
        if (Vector3.Distance(pickUpTransform.position, playerPosition.position) <= pickDistance)
        {
            return true;
        }
        return false;
    }

    private void Update()
    {
        pickUpTransform.rotation = new Quaternion(0, CameraSingleton.cameraTransform.rotation.y, 0, CameraSingleton.cameraTransform.rotation.w);
    }
}
