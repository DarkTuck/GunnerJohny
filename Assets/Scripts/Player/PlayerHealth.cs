using NaughtyAttributes;
using UnityEngine;


public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField][Foldout("Events")] HealthArmorScriptableObject playerHealth, playerArmor;
    [SerializeField] int health, armor;
    [SerializeField] private Animator animator;
    [SerializeField][Foldout("Maxes")] int maxHealth = 200, maxArmor = 200;
    [SerializeField][Foldout("Audio")] AudioSource audioSource;
    [SerializeField][Foldout("Audio")] AudioClip damageSound,deathSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerHealth.IntValue=health;
        playerArmor.IntValue = armor;
        playerArmor.max=maxArmor;
        playerHealth.max=maxHealth;
        
    }

    public void Damage(int damage)
    {
        if (playerHealth.IntValue > 0)
        {
            playerHealth.IntValue -=/* Mathf.Clamp( Mathf.RoundToInt(((float)damage*0.6f)),0,MaxHealth)*/Mathf.RoundToInt(((float)damage*0.6f));
            playerArmor.IntValue = Mathf.Clamp(  playerArmor.IntValue-Mathf.RoundToInt(((float)damage*0.3f)),0,maxArmor);
            animator.SetInteger("Health",playerHealth.IntValue);
            audioSource.PlayOneShot(damageSound);
            
        }
        else
        {
            playerHealth.IntValue -= damage;
            audioSource.PlayOneShot(deathSound);
        }

        if (playerHealth.IntValue <= 0)
        {
            Kill();
        }

        
    }

    void Kill()
    {
        Debug.Log("Player is dead");
        audioSource.PlayOneShot(deathSound);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
