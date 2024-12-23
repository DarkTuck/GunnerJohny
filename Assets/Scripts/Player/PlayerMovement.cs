using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Actions actions; //popięcie do klasy z inputem
    [SerializeField] float speed = 5;
    
    //[SerializeField] Animator animator;
    //[SerializeField] PlayerWeapon weaponScript;
    //[SerializeField] ParticleSystem dustParticle;
    //private Rigidbody rb;
    private InputAction move; //odbiera input z akcji move
    private Transform player;
    // Start is called before the first frame update
    private void OnEnable()
    {
        //głównie podpina input do wartości w skrypcie
        actions.Player.Enable();
        move = actions.Player.Move;
    }
    private void OnDisable()
    {
        //zwalnianie ramu.exe
        actions.Player.Disable();
    }

    private void Awake()
    {
        //Jebać ręczne podpinanie
        //rb = GetComponent<Rigidbody>();
        actions = new Actions();
        player = transform;
        //weaponScript = GetComponentInChildren<PlayerWeapon>();

    }

    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 moveDirection=new Vector3(move.ReadValue<Vector2>().x,0,move.ReadValue<Vector2>().y);
        player.Translate(moveDirection*speed, Space.Self);
        //if (moveDirection != Vector3.zero) { AudioManager.instance.PlayOneShot(AudioManager.instance.Footstep, this.transform.position); }
    }
    //SEX NIE ISTNIEJE
}
