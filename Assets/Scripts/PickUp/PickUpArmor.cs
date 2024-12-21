using UnityEngine;
using UnityEngine.Serialization;

public class PickUpArmor : PickUpScript
{
    [SerializeField] HealthArmorScriptableObject ArmorInt;
    [FormerlySerializedAs("HealthArmorPickUp")] [SerializeField] HealthArmorPickUp healthArmorPickUp;

    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = healthArmorPickUp.healthArmorSprite;
    }

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
