using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;


public class DoorBackUpScript : MonoBehaviour
{
   Actions actions;
    [SerializeField] float distance, doorOpenTime=1f,doorHight;
    [SerializeField] AudioClip doorOpenSound, doorCloseSound;
    Transform player;
    [SerializeField]AudioSource doorAudio;
    Vector3 doorPos;
    [SerializeField]Transform door;
    bool doorOpen, doorCanBeOpened;

    void Awake()
    {
        actions = new Actions();
        
    }

    void OnEnable()
    {
        actions.Enable();
    }

    void OnDisable()
    {
        actions.Disable();
        actions.Player.Interact.started -= TryToOpenDoor;
    }
    void Start()
    {
        player = PlayerSingleton._player.transform;
        doorPos = door.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerSingleton playerSingleton = other.gameObject.GetComponent<PlayerSingleton>();
        if (playerSingleton != null)
        {
            actions.Player.Interact.started += TryToOpenDoor;
        }
    }

    void OnTriggerExit(Collider other)
    {
        PlayerSingleton playerSingleton = other.gameObject.GetComponent<PlayerSingleton>();
        if (playerSingleton != null)
        {
            actions.Player.Interact.started -= TryToOpenDoor;
        }
    }

    /* private void FixedUpdate()
    {
        if (doorCanBeOpened==false && Vector3.Distance(new Vector3(Mathf.Round(player.position.x),0), new Vector3(Mathf.Round(doorPos.x),0)) <= distance)
        {
            Debug.Log(Vector3.Distance(new Vector3(Mathf.Round(player.position.x),0), new Vector3(Mathf.Round(doorPos.x),0)) );
            actions.Player.Interact.started += TryToOpenDoor;
            doorCanBeOpened = true;
        }
        else if (Vector3.Distance(new Vector3(player.transform.position.x,0), new Vector3(doorPos.x,0)) >= doorOpenTime)
        {
            actions.Player.Interact.started -= TryToOpenDoor;
            doorCanBeOpened = false;
        }
        //Debug.Log(@$"doorCanBeOpened:{doorCanBeOpened}");
    }
    */

    void OpenDoor()
    {
        //Debug.Log("Open door");
        door.DOMove(doorPos+(Vector3.up*doorHight), duration: doorOpenTime);
        doorAudio.PlayOneShot(doorOpenSound);
    }

    void CloseDoor()
    {
        //Debug.Log("Close door");
        door.DOMove(doorPos, duration: doorOpenTime);
        doorAudio.PlayOneShot(doorCloseSound);
    }

    void TryToOpenDoor(InputAction.CallbackContext context)
    {
        if (!doorOpen)
        {
            OpenDoor();
            doorOpen = true;
            return;
        }
        CloseDoor();
        doorOpen = false;
    }
}
