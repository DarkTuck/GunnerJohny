using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Jobs;
using Unity.Collections;
using UnityEngine.UI;
using DG.Tweening;
using Random = UnityEngine.Random;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] Weapon[] weapons;
    Actions actions;
    [SerializeField]Ammuniton ammo;
    [SerializeField]IntEvent currentWeapon,weaponCount;
    [SerializeField] LayerMask hitLayers;
    [SerializeField] AudioSource audio;
    [SerializeField] Image weaponRender;
    [SerializeField] Animator animator, faceAnimator;
    private bool isShooting=false;

    //Sequence changeWeapon = DOTween.Sequence();
    void Awake()
    {
        actions = new Actions();

    }

    void OnEnable()
    {
        actions.Enable();
        actions.Player.Attack.started += Shoot;
        actions.Player.Select.performed += SelectWeapon;
    }

    void OnDisable()
    {
        actions.Disable();
        actions.Player.Attack.performed -= Shoot;
        actions.Player.Select.performed -= SelectWeapon;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ammo.InitializeAmmunitons();
        weaponRender.sprite = weapons[currentWeapon.IntValue].weaponModel;
        animator.SetInteger("currentWeapon",currentWeapon.IntValue);
        Cursor.lockState = CursorLockMode.Locked;
        weaponCount.IntValue=weapons.Count(x=>x != null);
        currentWeapon.IntValue=0;
        //audio.clip = weapons[currentWeapon].shoot;
        /*
        for (int i = 0; i < weapons.Length; i++)
        {
            if (weapons[i] != null)
            {
                weapons[i].currentAmmo = weapons[i].ammoCount;
            }
        }
        */
    }

    public void PickUpWeapon(Weapon weapon)
    {
        weapons[weaponCount.IntValue = weapons.Count(x => x != null)] = weapon;
        weaponCount.IntValue=weapons.Count(x=>x != null);
    }
    async Task changeWeaponTask()
    {
        Tween tween = weaponRender.rectTransform.DOAnchorPosY(-265.5f, weapons[currentWeapon.IntValue].equipTime);
        await tween.AsyncWaitForCompletion();
        weaponRender.sprite = weapons[currentWeapon.IntValue].weaponModel;
        animator.SetInteger("currentWeapon",currentWeapon.IntValue);
        Tween tween2 = weaponRender.rectTransform.DOAnchorPosY(-164.5f,weapons[currentWeapon.IntValue].equipTime);
        await tween2.AsyncWaitForCompletion();

    }
    async void SelectWeapon(InputAction.CallbackContext context)
    {
        if (!isShooting)
        {
            if (context.ReadValue<float>() > 0 && currentWeapon.IntValue != weapons.Length - 1)
            {
                if (weapons[currentWeapon.IntValue + 1] != null)
                {

                    currentWeapon.IntValue++;
                    await changeWeaponTask();
                    //audio.clip = weapons[currentWeapon].shoot;
                }
            }
            else if (context.ReadValue<float>() < 0 && currentWeapon.IntValue != 0)
            {
                if (weapons[currentWeapon.IntValue - 1] != null)
                {

                    currentWeapon.IntValue--;
                    await changeWeaponTask();
                    //audio.clip = weapons[currentWeapon].shoot;
                }
            }
        }
    }

    #region Shooting
    void Shoot(InputAction.CallbackContext context)
    {
        if (!isShooting)
        {
            isShooting=true;
            switch (weapons[currentWeapon.IntValue].weaponType)
            {
                case WeaponType.pistol:
                    StartCoroutine(nameof(FR));
                    break;
                case WeaponType.minigun:
                    StartCoroutine(nameof(FR));
                    break;
                case WeaponType.shotgun:
                    FireRayShotgun();
                    break;
                default:
                    StartCoroutine(nameof(FP));
                    break;
            }
        }
    }

    IEnumerator FR() //Fire Ray
    {
        Debug.Log("FR");
        while (actions.Player.Attack.IsPressed()&&ammo.Ammunitons[weapons[currentWeapon.IntValue].ammoType].IntValue>0)
        {
            FireRay();
            Debug.Log("fired");
            SameForAllGuns();

            yield return new WaitForSeconds(weapons[currentWeapon.IntValue].fireRate);
        }
        faceAnimator.SetBool("shooting",false);
        isShooting=false;

    }

    IEnumerator FP()
    {
        while (actions.Player.Attack.IsPressed() && ammo.Ammunitons[weapons[currentWeapon.IntValue].ammoType].IntValue > 0)
        {
            Debug.Log("FP");
            FireProjectile();
            SameForAllGuns();

            yield return new WaitForSeconds(weapons[currentWeapon.IntValue].fireRate);
        }
        faceAnimator.SetBool("shooting",false);
        isShooting = false;
    }
    

    void FireRay()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit,hitLayers))
        {
//            Debug.Log(hit.collider.gameObject.name);
            IDamageable damageable = hit.collider.gameObject.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.Damage(weapons[currentWeapon.IntValue].damage);
            }
        }
    }

    #region Shotgun
    private async void FireRayShotgun()
    {
        while (actions.Player.Attack.IsPressed() && ammo.Ammunitons[weapons[currentWeapon.IntValue].ammoType].IntValue > 0)
        {
            SameForAllGuns();
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit raycastHit, hitLayers))
            {
                Debug.Log(raycastHit.collider.gameObject.name);
                IDamageable damageable = raycastHit.collider.gameObject.GetComponent<IDamageable>();
                if (damageable != null)
                {
                    damageable.Damage(weapons[currentWeapon.IntValue].damage);
                }
            }

            var results = new NativeArray<RaycastHit>(50, Allocator.TempJob);

            var commands = new NativeArray<RaycastCommand>(50, Allocator.TempJob);
            QueryParameters queryParameters = default;
            queryParameters.layerMask = hitLayers;
            queryParameters.hitMultipleFaces = true;
            // Set the data of the first command
            Vector3 origin = transform.position;

            for (int i = 0; i < commands.Length; i++)
            {
                commands[i] = new RaycastCommand(origin,
                    transform.forward + new Vector3(Random.Range(0.01f, 0.15f), 0, 0), queryParameters);
            }

            // Schedule the batch of raycasts.
            JobHandle handle = RaycastCommand.ScheduleBatch(commands, results, 1, default(JobHandle));

            // Wait for the batch processing job to complete
            handle.Complete();

            // Copy the result. If batchedHit.collider is null there was no hit
            foreach (var hit in results)
            {
                if (hit.collider != null)
                {
                    IDamageable damageable = hit.collider.gameObject.GetComponent<IDamageable>();
                    if (damageable != null)
                    {
                        damageable.Damage(weapons[currentWeapon.IntValue].damage);
                    }
                }
            }

            await ShotgunDelay();
        }
        faceAnimator.SetBool("shooting",false);
        isShooting=false;
    }

    private async Task ShotgunDelay()
    {
        await Task.Delay(((int)weapons[currentWeapon.IntValue].fireRate)*1000);//counts in ms so *1000 is for converting it to seconds
    }
    #endregion   

    void SameForAllGuns()
    {
        ammo.Ammunitons[weapons[currentWeapon.IntValue].ammoType].IntValue--;
        audio.PlayOneShot(weapons[currentWeapon.IntValue].shoot);
        animator.SetTrigger("fire");
        faceAnimator.SetBool("shooting",true);
        
    }
    void FireProjectile()
    {
        
    }
    #endregion
}
