using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetsumeiButton : MonoBehaviour {

    [SerializeField] GameObject m_LoversImage;
    [SerializeField] GameObject m_PressAnyKey;
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

    // Update is called once per frame
    void Update ()
    {
        if (!m_bReady)
        {
            return;
        }

        if (Input.anyKeyDown)
        {
            Destroy(GameObject.Find("Character"));
            Destroy(GameObject.Find("StartButton"));
            Destroy(GameObject.Find("QuitButton"));
            Destroy(GameObject.Find("SetsumeiButton"));

            CreateInstance(m_LoversImage);
            GameObject newObject = CreateInstance(m_PressAnyKey);
            newObject.transform.localPosition = new Vector3(4.25f, -4.0f, 0.0f);
            newObject.transform.localScale = new Vector2(1.5f, 1.5f);

            GetComponent<AudioManager>().AudioPlayClipAtPoint(0);
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

    private GameObject CreateInstance(GameObject _createObject)
    {
        GameObject newobject = Instantiate(_createObject);
        newobject.name = _createObject.name;
        return newobject;
    }
}
