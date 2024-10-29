using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set60FPS : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Set the target frame rate to 60 frames per second
        Application.targetFrameRate = 60;

        // Never turn screen off
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
}
