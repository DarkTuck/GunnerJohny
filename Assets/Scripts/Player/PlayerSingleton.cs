using UnityEngine;

public class PlayerSingleton : MonoBehaviour
{
    private static PlayerSingleton _instance;

    public static Transform _player
    {
        get => _instance.transform;
        private set { }
    }

    private IDamageable _playerDamage;
    public static IDamageable _damageable
    {
        get => _instance._playerDamage;
        private set { }
    }
    
    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            _player = gameObject.transform;
            _playerDamage = gameObject.GetComponent<IDamageable>();
        }
    }
}
