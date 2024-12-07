using UnityEngine;
using UnityEngine.Serialization;

public class PickUpArmor : PickUpScript
{
    [SerializeField] HealthArmorScriptableObject ArmorInt;
    [FormerlySerializedAs("HealthArmorPickUp")] [SerializeField] HealthArmorPickUp healthArmorPickUp;

    void FixedUpdate()
    {
        if (CheckDistance())
        {
            if (ArmorInt.IntValue + healthArmorPickUp.healthArmor <= ArmorInt.max)
            {
                ArmorInt.IntValue += healthArmorPickUp.healthArmor;
                Destroy(gameObject);
            }
        }
    }
}
