using UnityEngine;
using System.Threading.Tasks;

public class EnemyHealth : MonoBehaviour , IDamageable
{
    int health;
    [SerializeField]Animator animator;
    [SerializeField] randomAudioClips randomAudioClips;
    [SerializeField] AudioSource audioSource;

    [SerializeField] private EnemyInt _enemyInt;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     health = _enemyInt.health;   
    }

   public void Damage(int damage)
    {
        health -= damage;
        animator.SetTrigger("die");
        Debug.Log(gameObject.name + health);
        if (health <= 0)
        {
            //gameObject.SetActive(false);
            animator.SetBool("walking",false);
            animator.Play("death");
            animator.SetBool("dead",true);
            gameObject.GetComponent<SetTarget>().enabled = false;
            gameObject.GetComponent<CloseAttack>().enabled = false;
            audioSource.PlayOneShot(randomAudioClips.GetRandomClip());
            PlayerSingleton.SetFaceKillTrigger();
            _ = DisableAfterDeath();

        }

        async Task DisableAfterDeath()
        {
            await Task.Delay(7*100);
            gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
