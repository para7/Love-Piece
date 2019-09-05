using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour {
    private SpriteRenderer m_spriteRender;
    private bool m_bReady;

    // Use this for initialization
    void Start()
    {
        m_spriteRender = GetComponent<SpriteRenderer>();
        var color = m_spriteRender.color;
        color.a = 0.5f;
        m_spriteRender.color = color;
        m_bReady = false;
    }

    void Update()
    {
        if (!m_bReady)
        {
            return;
        }

        if (Input.anyKeyDown)
        {
            GetComponent<AudioManager>().AudioPlayClipAtPoint(0);
            Quit();
        }
    }

    void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
    UnityEngine.Application.Quit();
#endif
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var color = m_spriteRender.color;
            color.a = 1.0f;
            m_spriteRender.color = color;
            m_bReady = true;
            Debug.Log("HIT");
            GetComponent<AudioManager>().AudioPlay(1);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var color = m_spriteRender.color;
            color.a = 0.5f;
            m_spriteRender.color = color;
            m_bReady = false;
            Debug.Log("noHIT");
        }
    }
}
