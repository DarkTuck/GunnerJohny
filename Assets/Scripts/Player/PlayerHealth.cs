using System;
using NaughtyAttributes;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField][Foldout("Events")] HealthArmorScriptableObject playerHealth, playerArmor;
    [SerializeField] int health, armor;
    [SerializeField][Foldout("Maxes")] int maxHealth = 200, maxArmor = 200;
    [SerializeField][Foldout("Audio")] AudioSource audioSource;
    [SerializeField][Foldout("Audio")] AudioClip damageSound,deathSound;
    private Actions actions;
    void Awake()
    {
        actions = new Actions();
    }

    private void OnEnable()
    {
        actions.Enable();
        actions.Player.Relode.performed += DamagedTest;
    }
    void OnDisable()
    {
        actions.Disable();
        actions.Player.Relode.performed -= DamagedTest;
    }

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

    void DamagedTest(InputAction.CallbackContext ctx)
    {
        Damage(10);
    }
}
