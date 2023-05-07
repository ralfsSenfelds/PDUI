using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    private Button button;
    private AudioSource audioSource;

    private void Start()
    {
        // Get the Button component attached to the same game object
        button = GetComponent<Button>();

        // Get the AudioSource component attached to the same game object or its children
        audioSource = GetComponent<AudioSource>();
    }

    private void PlayButtonSound()
    {
        // Play the audio clip associated with the AudioSource
        audioSource.Play();
    }
}