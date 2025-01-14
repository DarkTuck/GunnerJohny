using System.Threading.Tasks;
using UnityEngine;

public class AcidDamage : MonoBehaviour
{
    [SerializeField] private int Seconds,damage;
    bool inAcid = false;
    private void OnCollisionEnter(Collision other)
    {
        IDamageable damageable = other.gameObject.GetComponent<IDamageable>();
        if(damageable != null&& !inAcid)
        {
            inAcid = true;
            Damage(damageable);
        }
    }

    void OnCollisionExit(Collision other)
    {
        inAcid = false;
    }

    async void Damage(IDamageable damageable)
    {
        while (inAcid)
        {
            damageable.Damage(damage);
            await Task.Delay(Seconds * 1000);
        }

    }
}
