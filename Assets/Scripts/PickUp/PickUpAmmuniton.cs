using UnityEngine;

public class PickUpAmmuniton : PickUpScript
{
    [SerializeField] private AmmoPickUp pickUpAmmunition;
    [SerializeField] private Ammuniton ammunition;
    AudioSource audio;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audio = GetComponent<AudioSource>();
        gameObject.GetComponent<SpriteRenderer>().sprite = pickUpAmmunition.ammoSprite;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (CheckDistance())
        {
            pickUpAmmunition.PickUpAmmo(ammunition);
            audio.PlayOneShot(pickUpAmmunition.pickUpSound);
            gameObject.SetActive(false);
        }
    }
    
}
