using UnityEngine;

public class PlayerPosSingleton : MonoBehaviour
{
    private static PlayerPosSingleton _instance;

    public static Transform _player
    {
        get { return _instance.transform; }
        private set { }
    }
    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            _player = gameObject.transform;
        }
    }
}
