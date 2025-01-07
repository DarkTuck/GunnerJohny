using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
    
public class Cheats : MonoBehaviour
{
    Actions actions;
    [SerializeField] Ammuniton ammo;
    [SerializeField] HealthArmorScriptableObject health,armor;

    void Awake()
    {
        actions = new Actions();
        DontDestroyOnLoad(this.gameObject);
    }

    void OnEnable()
    {
        actions.Enable();
        actions.Cheats.AddAmmo.performed += AddAmmo;
        actions.Cheats.AddHealth.performed += AddHealth;
        actions.Cheats.LoadMenu.performed += LoadMenu;
        actions.Cheats.LoadEndScreen.performed += LoadEndMenu;
        actions.Cheats.LoadGameScreen.performed +=LoadGame;
    }

    void OnDisable()
    {
        actions.Disable();
        actions.Cheats.AddAmmo.performed -= AddAmmo;
        actions.Cheats.AddHealth.performed -= AddHealth;
        actions.Cheats.LoadMenu.performed -= LoadMenu;
        actions.Cheats.LoadEndScreen.performed -= LoadEndMenu;
        actions.Cheats.LoadGameScreen.performed -= LoadGame;
        
    }

    void LoadMenu(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene(0);
    }

    void LoadEndMenu(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene(2);
    }

    void LoadGame(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene(1);
    }
    
    
    void LoadScene(int sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    void AddAmmo(InputAction.CallbackContext context)
    {
        ammo.AddAmmuniton();
    }

    void AddHealth(InputAction.CallbackContext context)
    {
        health.IntValue=health.max;
    }

    void AddArmor(InputAction.CallbackContext context)
    {
        armor.IntValue = armor.max;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
