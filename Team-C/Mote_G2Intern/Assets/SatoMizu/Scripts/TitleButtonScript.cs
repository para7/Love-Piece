using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButtonScript : MonoBehaviour
{
    [SerializeField]    private string m_SceneName;
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
            GetComponent<AudioManager>().AudioPlay(0);
            FadeManager.Instance.LoadScene(m_SceneName, 2.0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var color = m_spriteRender.color;
            color.a = 1.0f;
            m_spriteRender.color = color;
            m_bReady = true;
            GetComponent<AudioManager>().AudioPlay(1);
            Debug.Log("HIT");
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