using UnityEngine;
using System.Collections;

public class StartAudio : MonoBehaviour
{
    public AudioSource VoiceOver;
    public float Delay;
    // Use this for initialization
    private void Awake()
    {
        StartCoroutine(PlaySoundAfterDelay(VoiceOver, Delay));
    }

    IEnumerator PlaySoundAfterDelay(AudioSource VoiceOver, float delay)
    {
        if (VoiceOver == null)
            yield break;
        yield return new WaitForSeconds(delay);
        VoiceOver.Play();
    }

}