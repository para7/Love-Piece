using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    private AudioSource[] m_audioSources;


    // Use this for initialization
    void Awake()
    {
        m_audioSources = this.GetComponents<AudioSource>();
    }

    public void AudioPlay(int _index)
    {
        m_audioSources[_index].Play();
    }
}
