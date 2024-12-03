using UnityEngine;

public class EnemyHealth : MonoBehaviour , IDamageable
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

   public void Damage(int damage)
    {
        Debug.Log(damage);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
