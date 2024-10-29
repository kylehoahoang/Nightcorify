using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class BeatListPopulator : MonoBehaviour
{
    public GameObject buttonPrefab;
    public Transform contentPanel;
    public AudioSource audioSource; // GameObject containing the audio source we want to change

    public GameObject drumtab;

    void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        PopulateList();
    }

    void PopulateList()
    {
        Object[] resources = Resources.LoadAll("Drum Beats");

        // Iterate through each loaded object
        foreach (Object resource in resources)
        {
            string songName = resource.name;

            GameObject newButton = Instantiate(buttonPrefab) as GameObject;
            newButton.GetComponentInChildren<Text>().text = songName;
            newButton.transform.SetParent(contentPanel, false);

            // Attach onClick event
            newButton.GetComponent<Button>().onClick.AddListener(() => OnButtonClick(songName));
        }

        //drumtab.SetActive(false);
    }

    void OnButtonClick(string songName)
    {
        // Get the AudioSource component from the audioGameObject
        audioSource.clip = Resources.Load("Drum Beats/" + songName) as AudioClip;
        audioSource.Play();
    }

}
