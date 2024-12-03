using UnityEngine;

[CreateAssetMenu(fileName = "AmmoPickUp", menuName = "PickUp's/Ammo")]
public class AmmoPickUp : ScriptableObject
{
    [SerializeField] int ammo;
    [SerializeField] AmmunitonType ammoType;
    public Sprite ammoSprite;
    

    public void PickUpAmmo(Ammuniton ammuniton)
    {
        ammuniton.ammunitons[ammoType] += ammo;
    }
}
