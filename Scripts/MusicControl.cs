using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class MusicControl : MonoBehaviour {

    public AudioClip[] stings;
    public AudioSource stingSource;
    public float bpm = 128;

    // Use this for initialization
    void Start()
    {
        PlaySong();
    }

    void PlaySong()
    {
        int randClip = Random.Range(0, stings.Length);
        stingSource.clip = stings[randClip];
        stingSource.volume = 0.1f;
        stingSource.Play();
    }
}
