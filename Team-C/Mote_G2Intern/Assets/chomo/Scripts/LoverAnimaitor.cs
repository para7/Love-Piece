using UnityEngine;

public class LoverAnimaitor : MonoBehaviour
{
    [SerializeField] private Sprite m_defaltSprite;

    [SerializeField] private Sprite m_fallInLoveSprite;

    private SpriteRenderer m_spriteRenderer;

    private ParticleSystem m_particleSystem;

    private void Awake()
    { 
        m_spriteRenderer = GetComponent<SpriteRenderer>();

        m_particleSystem = GetComponent<ParticleSystem>();
    }

    private void Start()
    {
        m_spriteRenderer.sprite = m_defaltSprite;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") ||
            collision.gameObject.CompareTag("ResultArea"))
        {
            m_spriteRenderer.sprite = m_fallInLoveSprite;

            if (!m_particleSystem.isPlaying)
            {

                m_particleSystem.Play();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") ||
            collision.gameObject.CompareTag("ResultArea"))
        {
            m_spriteRenderer.sprite = m_defaltSprite;

            m_particleSystem.Stop();
            //m_particleSystem.Pause();
        }
    }
}
