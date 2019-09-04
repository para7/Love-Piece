using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    private const int CLIP_MAX = 10;
    public AudioClip[] m_audioclip = new AudioClip[CLIP_MAX];

    private AudioSource[] m_audioSource;


    // Use this for initialization
    void Start()
    {
        m_audioSource = gameObject.GetComponents<AudioSource>();

        for (int i = 0; i < CLIP_MAX; i++)
        {
            if (m_audioclip[i])
            {
                m_audioSource[i].clip = m_audioclip[i];
            }
        }
    }

    public void AudioPlay(int _index)
    {
        m_audioSource[_index].Play();
    }
}
