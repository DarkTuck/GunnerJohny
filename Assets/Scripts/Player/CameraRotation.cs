using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 0.15f;
    Actions action;
    private InputAction rotate;
    
    
    private void Awake()
    {
        action= new Actions();
    }
    private void OnEnable()
    {
        action.Player.Enable();
        rotate = action.Player.Look;
    }
    private void OnDisable()
    {
        action.Player.Disable();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.Rotate(new Vector3(0, rotate.ReadValue<Vector2>().x*rotationSpeed, 0));
    }

}
