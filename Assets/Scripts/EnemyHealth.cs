using UnityEngine;

public class EnemyHealth : MonoBehaviour , IDamageable
{
    [SerializeField]int health = 100;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

   public void Damage(int damage)
    {
        health -= damage;
        Debug.Log(gameObject.name + health);
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
