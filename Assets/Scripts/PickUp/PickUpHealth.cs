using UnityEngine;

public class PickUpHealth : PickUpScript
{
    [SerializeField] HealthArmorScriptableObject healthEvent;
    [SerializeField] HealthArmorPickUp healthArmorPickUp;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = healthArmorPickUp.pickUpSound;
        gameObject.GetComponent<SpriteRenderer>().sprite= healthArmorPickUp.healthArmorSprite;
    }
    void FixedUpdate()
    {
        if (CheckDistance())
        {
            if(healthEvent.IntValue+healthArmorPickUp.healthArmor<=healthEvent.max)
            {
                healthEvent.IntValue +=healthArmorPickUp.healthArmor;
                audioSource.Play();
                Destroy(gameObject);
            }
        }
    }
}
