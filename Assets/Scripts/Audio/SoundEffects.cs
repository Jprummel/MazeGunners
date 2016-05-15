using UnityEngine;
using System.Collections;

public class SoundEffects : MonoBehaviour {

    public AudioClip[] soundEffects;
    private AudioSource _audio;
	// Use this for initialization
	void Start () {
        _audio = GetComponent<AudioSource>();
	}
	
	public void PlaySound(int soundNumber)
    {
        _audio.PlayOneShot(soundEffects[soundNumber]);
    }
}
