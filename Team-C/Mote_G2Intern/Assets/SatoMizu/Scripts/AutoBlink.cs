using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoBlink : MonoBehaviour {

    [SerializeField] private float m_speed;
    private bool m_bPlus;
    private SpriteRenderer m_spriteRender;

    // Use this for initialization
    void Start ()
    {
        m_spriteRender = GetComponent<SpriteRenderer>();
        var color = m_spriteRender.color;
        color.a = 0.0f;
        m_spriteRender.color = color;
        m_bPlus = true;
    }
	
	// Update is called once per frame
	void Update () {
        var color = m_spriteRender.color;
        if (m_bPlus)
        {
            color.a += m_speed;
            if(color.a > 1.0f)
            {
                color.a = 1.0f;
                m_bPlus = false;
            }
        }
        else
        {
            color.a -= m_speed;
            if (color.a < 0.0f)
            {
                color.a = 0.0f;
                m_bPlus = true;
            }
        }

        m_spriteRender.color = color;
    }
}
