using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

public class DoorScript : MonoBehaviour
{
    Actions actions;
    [SerializeField] float distance, doorOpenTime=1f,doorHight;
    [SerializeField] AudioClip doorOpenSound, doorCloseSound;
    Transform player;
    Vector3 doorPos;
    AudioSource doorAudio;
    bool doorOpen, doorCanBeOpened;

    void Awake()
    {
        actions = new Actions();
        AudioSource audio = GetComponent<AudioSource>();
        doorAudio = audio == null ? gameObject.AddComponent<AudioSource>() : audio;
        
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
        doorPos = transform.position;
    }

    private void FixedUpdate()
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

    void OpenDoor()
    {
        //Debug.Log("Open door");
        transform.DOMove(doorPos+(Vector3.up*doorHight), duration: doorOpenTime);
        doorAudio.PlayOneShot(doorOpenSound);
    }

    void CloseDoor()
    {
        //Debug.Log("Close door");
        transform.DOMove(doorPos, duration: doorOpenTime);
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
