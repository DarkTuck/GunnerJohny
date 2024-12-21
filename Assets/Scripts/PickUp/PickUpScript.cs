using System;
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

    private void Update()
    {
        transform.rotation = new Quaternion(0, CameraSingleton.cameraTransform.rotation.y, 0, CameraSingleton.cameraTransform.rotation.w);
    }
}
