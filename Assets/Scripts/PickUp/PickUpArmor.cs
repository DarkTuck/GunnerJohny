using UnityEngine;
using UnityEngine.Serialization;

public class PickUpArmor : PickUpScript
{
    [SerializeField] HealthArmorScriptableObject ArmorInt;
    [FormerlySerializedAs("HealthArmorPickUp")] [SerializeField] HealthArmorPickUp healthArmorPickUp;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameObject.GetComponent<SpriteRenderer>().sprite = healthArmorPickUp.healthArmorSprite;
    }

    void FixedUpdate()
    {
        if (CheckDistance())
        {
            if (ArmorInt.IntValue + healthArmorPickUp.healthArmor <= ArmorInt.max)
            {
                ArmorInt.IntValue += healthArmorPickUp.healthArmor;
                audioSource.PlayOneShot(healthArmorPickUp.pickUpSound);
                Destroy(gameObject);
            }
        }
    }
}
