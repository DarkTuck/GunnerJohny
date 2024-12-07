using UnityEngine;

public class PickUpHealth : PickUpScript
{
    [SerializeField] HealthArmorScriptableObject healthEvent;
    [SerializeField] HealthArmorPickUp healthArmorPickUp;

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
