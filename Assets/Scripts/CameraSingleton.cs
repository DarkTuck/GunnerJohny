using UnityEngine;

public class CameraSingleton : MonoBehaviour
{
    public static CameraSingleton instance;
    public static Transform cameraTransform;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        cameraTransform = transform;
    }
    
}
