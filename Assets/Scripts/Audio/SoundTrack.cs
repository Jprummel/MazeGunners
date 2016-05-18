using UnityEngine;
using System.Collections;

//Author Jordi Prummel

public class SoundTrack : MonoBehaviour
{
    public  AudioClip[] soundtrack;
    private AudioSource _audio;

    // Use this for initialization
    void Start()
    {
        _audio = GetComponent<AudioSource>();

        if (!_audio.playOnAwake)
        {
            _audio.clip = soundtrack[Random.Range(0, soundtrack.Length)];
            _audio.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!_audio.isPlaying)
        {
            _audio.clip = soundtrack[Random.Range(0, soundtrack.Length)];
            _audio.Play();
            
        }
    }
}