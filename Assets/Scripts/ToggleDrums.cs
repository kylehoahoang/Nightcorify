using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleDrums : MonoBehaviour
{
    public GameObject objectToHide;
    private bool isActive = false;

    public void ToggleObject()
    {
        if (objectToHide != null)
        {
            if (isActive)
            {
                objectToHide.SetActive(false);
                isActive = false;
            }
            else {
                objectToHide.SetActive(true);
                isActive = true;
            }
            
        }
    }
}
