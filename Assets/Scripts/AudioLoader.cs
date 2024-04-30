using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioLoader : MonoBehaviour
{
    public AudioClip audioClip; // Drag and drop the audio clip in the Inspector
    private AudioSource audioSource;

    private void Start()
    {
        // Check if an AudioSource component is already attached
        audioSource = GetComponent<AudioSource>();

        // If not, add an AudioSource component to the GameObject
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    // Method to be called when the audio should be played or paused
    public void ToggleAudio()
    {
        // Check if an audio clip is assigned
        if (audioClip != null)
        {
            if (audioSource.isPlaying)
            {
                // If the audio is playing, pause it
                 audioSource.Stop();
            }
            else
            {
                // If the audio is not playing, play it
                audioSource.PlayOneShot(audioClip);
            }
        }
        else
        {
            Debug.LogWarning("Audio clip is not assigned!");
        }
    }

    // Method to be called when a scene should be loaded
   
}
