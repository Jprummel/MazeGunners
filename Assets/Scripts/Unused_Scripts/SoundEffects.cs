using UnityEngine;
using System.Collections;

public class SoundEffects : MonoBehaviour {

    public delegate void SoundEffect();
    public static event SoundEffect playSound;

    [SerializeField]private AudioClip[] soundEffects;
    private AudioSource _audio;
	// Use this for initialization
	void Start () {
        _audio = GetComponent<AudioSource>();
	}

    void OnEnable()
    {
        if (playSound != null)
        {
            //PlaySound();
        }
    }
	
	public void PlaySound(int soundNumber)
    {
        _audio.PlayOneShot(soundEffects[soundNumber]);
    }
}
