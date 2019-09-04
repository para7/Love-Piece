using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    [SerializeField]static private int CLIP_MAX;
    public AudioClip[] m_audioclip = new AudioClip[CLIP_MAX];

    private AudioSource[] m_audioSource;


	// Use this for initialization
	void Start () {
        m_audioSource = gameObject.GetComponents<AudioSource>();
        m_audioSource[0].clip = m_audioclip[0];
        m_audioSource[0].Play();
    }
}
