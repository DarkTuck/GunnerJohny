using UnityEngine;

[CreateAssetMenu(fileName = "HealthArmorPickUp", menuName = "PickUp's/HealthArmor")]
public class HealthArmorPickUp : ScriptableObject
{
    public int healthArmor;
    public Sprite healthArmorSprite;
    public AudioClip pickUpSound;
}
