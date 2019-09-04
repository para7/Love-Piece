using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    private AudioSource m_audioSource;


    // Use this for initialization
    void Awake()
    {
        m_audioSource = this.GetComponent<AudioSource>();
    }

    public void AudioPlay()
    {
        m_audioSource.Play();
    }
}
