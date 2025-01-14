using UnityEngine;

[CreateAssetMenu(fileName = "randomAudioClips", menuName = "audio/randomAudioClips")]
public class randomAudioClips : ScriptableObject
{
    public AudioClip[] audioClips;

    [HideInInspector]
    public AudioClip GetRandomClip()
    {
        return audioClips[Random.Range(0, audioClips.Length)];
    }
}
