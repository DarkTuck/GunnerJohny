using UnityEngine;

public class PickUpAmmuniton : PickUpScript
{
    [SerializeField] private AmmoPickUp pickUpAmmunition;
    [SerializeField] private Ammuniton ammunition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = pickUpAmmunition.ammoSprite;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (CheckDistance())
        {
            pickUpAmmunition.PickUpAmmo(ammunition);
            Destroy(this.gameObject);
        }
    }
    
}
