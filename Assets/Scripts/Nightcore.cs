using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PitchChanger : MonoBehaviour
{
    public AudioSource audioSource;
    private bool isHighPitch = false;
    private float lowPitch = 1.0f;
    private float highPitch = 1.18f;

    private Image buttonImage;
    public Button toggleBtn;

    void Start()
    {
        // Ensure that an AudioSource is assigned
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    public void TogglePitch()
    {
        if (isHighPitch)
        {
            audioSource.pitch = lowPitch; // Set to low pitch
            toggleBtn.GetComponent<Image>().color = new Color(0.45f, 0.54f, 0.62f ) ;

        }
        else
        {
            audioSource.pitch = highPitch; // Set to high pitch
            toggleBtn.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f);
            
        }

        isHighPitch = !isHighPitch; // Toggle the pitch state
    }
}
