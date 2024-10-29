using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpatialToggle : MonoBehaviour
{
    public AudioSource audioSource;
    private bool is2D = true;
    public CircularPath circularPathScript;
    public DragSprite dragSpriteScript;

    private float defaultX;
    private float defaultY;

    void Start()
    {
        // Ensure that an AudioSource is assigned
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        Transform transform = gameObject.transform;

        Vector3 position = transform.position;

        defaultX = position.x;
        defaultY = position.y;
    }

    public void ToggleSpatial()
    {
        if (is2D)
        {
            audioSource.spatialBlend = 1.0f;
            dragSpriteScript.enabled = true;
            circularPathScript.enabled = true;
            is2D = false;
        }
        else
        {
            audioSource.spatialBlend = 0.0f;
            transform.position = new Vector2(defaultX, defaultY);
            dragSpriteScript.enabled = false;
            circularPathScript.enabled = false;
            is2D = true;
        }
    }
}
