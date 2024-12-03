using System;
using NaughtyAttributes;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField][Foldout("Events")] IntEvent playerHealth, playerArmor;
    [SerializeField] int health, armor;
    [SerializeField][Foldout("Maxes")] int MaxHealth = 200, MaxArmor = 200;
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
        
    }

    public void Damage(int damage)
    {
        if (playerHealth.IntValue > 0)
        {
            playerHealth.IntValue -=/* Mathf.Clamp( Mathf.RoundToInt(((float)damage*0.6f)),0,MaxHealth)*/Mathf.RoundToInt(((float)damage*0.6f));
            playerArmor.IntValue = Mathf.Clamp(  playerArmor.IntValue-Mathf.RoundToInt(((float)damage*0.3f)),0,MaxArmor);
        }
        else
        {
            playerHealth.IntValue -= damage;
        }

        if (playerHealth.IntValue <= 0)
        {
            Kill();
        }

        
    }

    void Kill()
    {
        Debug.Log("Player is dead");
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
