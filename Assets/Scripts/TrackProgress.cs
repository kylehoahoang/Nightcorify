using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TrackProgress : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{
    private Slider _slider;
    public AudioSource _audioSource;
    public Text _trackTime;

    public Text _trackTimeTotal;
    private bool isDragging = false;

    // Start is called before the first frame update
    void Start()
    {
        if (_audioSource == null)
        {
            _audioSource = GetComponent<AudioSource>();
        }

        if (_slider == null)
        {
            _slider = gameObject.GetComponent<Slider>();
        }

        _slider.onValueChanged.AddListener((v) => {
            if (_audioSource.clip != null)
            {
                _audioSource.time = v * _audioSource.clip.length;
                // Convert the time to minutes and seconds format (without decimals)
                int minutes = Mathf.FloorToInt(_audioSource.time / 60f);
                int seconds = Mathf.FloorToInt(_audioSource.time % 60f);

                int minutesTotal = Mathf.FloorToInt(_audioSource.clip.length / 60f);
                int secondsTotal = Mathf.FloorToInt(_audioSource.clip.length % 60f);
                
                // Set the track time text
                _trackTime.text = string.Format("{0:00}:{1:00}", minutes, seconds);

                // Set the track time text
                _trackTimeTotal.text = string.Format("{0:00}:{1:00}", minutesTotal, secondsTotal);
            }
        });
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Pause the track when dragging begins
        isDragging = true;
        if (_audioSource != null && _audioSource.isPlaying)
        {
            _audioSource.Pause();
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Resume playback when dragging ends
        isDragging = false;
        if (_audioSource != null && !_audioSource.isPlaying)
        {
            _audioSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_audioSource.clip != null)
        {
            _slider.value = _audioSource.time / _audioSource.clip.length;
        }
        
    }
}
