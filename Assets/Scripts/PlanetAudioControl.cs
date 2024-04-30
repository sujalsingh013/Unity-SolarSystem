using UnityEngine;
using TMPro;

public class PlanetAudioControl : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // Hide the TextMeshPro button initially
       // GetComponent<TMP_Button>().gameObject.SetActive(false);
    }

    public void SetAudioClip(AudioClip audioClip)
    {
        if (audioSource == null)
        {
            // Add an AudioSource component if it doesn't exist
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        if (audioSource != null)
        {
            audioSource.clip = audioClip;
        }
    }

    public void PlayAudio()
    {
        // Play the assigned audio clip
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
        }
    }
}
