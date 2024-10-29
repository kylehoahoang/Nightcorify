using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausePlay : MonoBehaviour
{
    public AudioSource audioSource;
    public Sprite pause; // The sprite to change to
    public Sprite play; // The sprite to change to
    public Image imageobject;
    // Start is called before the first frame update
    void Start()
    {
        // Get the AudioSource component attached to the same GameObject
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void PausePlayToggle()
    {
        // Toggle pause/play
        if (audioSource.isPlaying)
        {
            // If currently playing, pause the audio
            audioSource.Pause();
            if (pause != null)
            {
            // Change the sprite
                imageobject.sprite = play;
            }
            Debug.Log("Audio paused");
        }
        else
        {
            // If paused, resume playing
            audioSource.Play();
            Debug.Log("Audio resumed");
            if (pause != null)
            {
            // Change the sprite
                imageobject.sprite = pause;
            }
        }
    }

    public void PausePlayToggleiOS(string message)
    {
        // Toggle pause/play
        if (message == "Pause")
        {
            // If currently playing, pause the audio
            audioSource.Pause();
        }
        else if (message == "Play")
        {
            // If paused, resume playing
            audioSource.Play();
        }
    }
    

}
