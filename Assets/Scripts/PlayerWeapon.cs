using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] Weapon[] weapons;
    Actions actions;
    [SerializeField]Ammuniton ammo;
    [SerializeField]private int currentWeapon=0;
    [SerializeField] LayerMask hitLayers;
    Coroutine RelodeCorutine;
    //private InputAction scroll;

    void Awake()
    {
        actions = new Actions();
    }

    void OnEnable()
    {
        actions.Enable();
        actions.Player.Attack.performed += Shoot;
        actions.Player.Select.performed += SelectWeapon;
        actions.Player.Relode.performed += PlayerRelode;
        //scroll = actions.Player.Select;
    }

    void OnDisable()
    {
        actions.Disable();
        actions.Player.Attack.performed -= Shoot;
        actions.Player.Select.performed -= SelectWeapon;
        actions.Player.Relode.performed -= PlayerRelode;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ammo.InitializeAmmunitons();
        for (int i = 0; i < weapons.Length; i++)
        {
            if (weapons[i] != null)
            {
                weapons[i].currentAmmo = weapons[i].ammoCount;
            }
        }
    }

    void SelectWeapon(InputAction.CallbackContext context)
    {
        if (context.ReadValue<float>() > 0&& currentWeapon != weapons.Length-1)
        {
            if (weapons[currentWeapon+1] != null)
            {
                currentWeapon++;
            }
        }
        else if(context.ReadValue<float>() <0 && currentWeapon !=0)
        {
            if (weapons[currentWeapon-1] != null)
            {
                currentWeapon--;    
            }
        }
    }

    #region Shooting
    void Shoot(InputAction.CallbackContext context)
    {
        //Coroutine fireMode;
        if (RelodeCorutine != null && weapons[currentWeapon].currentAmmo > 0)
        {
            CorutineStop(ref RelodeCorutine);
        }
        if (!weapons[currentWeapon].isProjectile)
        {
            Debug.Log("Not a projectile");
            StartCoroutine("FR");
        }
        else
        {
            Debug.Log("It's a projectile");
            StartCoroutine("FP");
        }
    }

    IEnumerator FR() //Fire Ray
    {
        Debug.Log("FR");
        while (actions.Player.Attack.IsPressed()&&weapons[currentWeapon].currentAmmo>0)
        {
            FireRay();
            Debug.Log("fired");
            weapons[currentWeapon].currentAmmo--;
            yield return new WaitForSeconds(weapons[currentWeapon].fireRate);
        }
        Relode();//ToThink: czy wstanienie relode w loop nie pozwoli strzelać ciągle z przewą na przeładowanie
        //also czy nie ma problemu możliwości strzelania i przeładowania jednoczśnie
    }

    IEnumerator FP()
    {
        while (actions.Player.Attack.IsPressed()&&weapons[currentWeapon].currentAmmo>0)
        {
           Debug.Log("FP");
           FireProjectile();
           weapons[currentWeapon].currentAmmo--;
           yield return new WaitForSeconds(weapons[currentWeapon].fireRate);
        }
        Relode();
        
    }
    

    void FireRay()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit,hitLayers))
        {
            Debug.Log(hit.collider.gameObject.name);
            IDamageable damageable = hit.collider.gameObject.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.Damage(weapons[currentWeapon].damage);
            }
        }
    }

    void FireProjectile()
    {
        
    }
    #endregion
#region Relode
    private void Relode()
    {
        if (weapons[currentWeapon].currentAmmo <= 0)
        {
            //CorutineStop(ref RelodeCorutine);
            CorutinStart(ref RelodeCorutine);
        }
    }
    bool CorutinStart(ref Coroutine coroutine/*,IEnumerator enumerato*/)
    {
        if (coroutine == null)
        {
            coroutine = StartCoroutine(Reloding());
            return true;
        }

        return false;
    }
    bool CorutineStop(ref Coroutine coroutine)
    {
        if (coroutine != null)
        {
            //currentTime = 0;
            StopCoroutine(coroutine);
            coroutine = null;
            return true;
        }
        return false;
    }
    private void PlayerRelode(InputAction.CallbackContext obj)
    {
        Weapon weapon = weapons[currentWeapon];
        if (weapon.currentAmmo < weapon.ammoCount)
        {
            //currentTime += relodSpeedUp;
            //animator.SetFloat("RelodeSpeed", animator.GetFloat("RelodeSpeed") + relodSpeedUp);
            //CorutineStop(ref RelodeCorutine);
            CorutinStart(ref RelodeCorutine);
        }
    }
    IEnumerator Reloding()
    {
        Weapon weapon = weapons[currentWeapon];
        yield return new WaitForSeconds(weapon.reloadTime);
        weapon.currentAmmo=weapon.ammoCount;
        
    }
    #endregion
    // Update is called once per frame
    void FixedUpdate()
    {

    }
}
