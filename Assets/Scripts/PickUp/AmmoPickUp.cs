using UnityEngine;

[CreateAssetMenu(fileName = "AmmoPickUp", menuName = "PickUp's/Ammo")]
public class AmmoPickUp : ScriptableObject
{
    [SerializeField] int ammo;
    [SerializeField] AmmunitonType ammoType;
    public Sprite ammoSprite;
    

    public void PickUpAmmo(Ammuniton ammuniton)
    {
        if (ammuniton.Ammunitons[ammoType].IntValue + ammo <= ammuniton.MaxAmmunitons[ammoType].IntValue)
        {
            ammuniton.Ammunitons[ammoType].IntValue += ammo;
        }
    }
}
