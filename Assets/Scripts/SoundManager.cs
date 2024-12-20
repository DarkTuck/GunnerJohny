using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public void PlaySound(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, transform.position);
    }

    public void PlayRandom(randomAudioClips clip)
    {
        AudioSource.PlayClipAtPoint(clip.audioClips[Random.Range(0,clip.audioClips.Length-1)], transform.position);
    }
}