using UnityEngine;

public class RotateToCamera : MonoBehaviour
{
    Transform cameraTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cameraTransform = CameraSingleton.cameraTransform.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = new Quaternion(0, cameraTransform.rotation.y, 0, cameraTransform.rotation.w);
    }
}
