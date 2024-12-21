using UnityEngine;

public class PickUpHealth : PickUpScript
{
    [SerializeField] HealthArmorScriptableObject healthEvent;
    [SerializeField] HealthArmorPickUp healthArmorPickUp;

    private void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite= healthArmorPickUp.healthArmorSprite;
    }
    void FixedUpdate()
    {
        if (CheckDistance())
        {
            if(healthEvent.IntValue+healthArmorPickUp.healthArmor<=healthEvent.max)
            {
                healthEvent.IntValue +=healthArmorPickUp.healthArmor;
                Destroy(gameObject);
            }
        }
    }
}
