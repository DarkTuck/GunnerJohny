using System.Collections;
using UnityEngine;

public class WatterAnimation : MonoBehaviour
{
    [SerializeField] Material []materials;
    [SerializeField]MeshRenderer rend;
    bool animate = true;
    private int currentAnimation = 0;
    [SerializeField] private float secondsToWait;

    void Start()
    {
        StartCoroutine(nameof(Animation));
    }
    IEnumerator Animation()
    {
        while (animate)
        {
            rend.material = materials[currentAnimation];
            currentAnimation++;
            if (currentAnimation >= materials.Length)
            {
                currentAnimation = 0;
            }
            yield return new WaitForSeconds(secondsToWait);
        }
    }
}
