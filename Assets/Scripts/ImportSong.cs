using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ImportSong : MonoBehaviour
{
    public string FinalPath;

    public AudioSource audioSource;
    public Image imageobject;
    public Sprite pause; // The sprite to change to

    void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    public void LoadFile()
    {
        string FileType = NativeFilePicker.ConvertExtensionToFileType("mp3");

        NativeFilePicker.Permission permission = NativeFilePicker.PickFile((path) => {
            if (path == null)
            {
                Debug.Log("Operation Cancelled");
            }
            else 
            {
                FinalPath = path;
                Debug.Log("Picked File: " + FinalPath);

                StartCoroutine(LoadAudioClipCoroutine(FinalPath));
            }
        }, new string[] { FileType });
    }
    
    IEnumerator LoadAudioClipCoroutine(string path)
    {
        // Create a UnityWebRequest object to load the MP3 file
        UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip("file://" + path, AudioType.MPEG);

        // Send the request and wait for it to complete
        yield return www.SendWebRequest();

        // Check for errors
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Failed to load audio clip: " + www.error);
            yield break;
        }

        // Get the downloaded audio clip
        AudioClip audioClip = DownloadHandlerAudioClip.GetContent(www);

        // Attach the audio clip to an AudioSource component
        audioSource.clip = audioClip;

        // Play the audio clip
        audioSource.Play();

        imageobject.sprite = pause;
    }
}
