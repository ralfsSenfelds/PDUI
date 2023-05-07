using UnityEngine;

public class SceneMusicPlayer : MonoBehaviour
{
    private void Start()
    {
        MusicController musicController = FindObjectOfType<MusicController>();
        if (musicController != null)
        {
            AudioSource audioSource = musicController.GetComponent<AudioSource>();
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }
}