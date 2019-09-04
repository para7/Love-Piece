using UnityEngine;

public class LoverAnimaitor : MonoBehaviour
{
    [SerializeField] private Sprite m_defaltSprite;

    [SerializeField] private Sprite m_fallInLoveSprite;

    private SpriteRenderer m_spriteRenderer;

    private void Awake()
    { 
        m_spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        m_spriteRenderer.sprite = m_defaltSprite;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") ||
            collision.gameObject.CompareTag("ResultArea"))
        {
            m_spriteRenderer.sprite = m_fallInLoveSprite;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")
            || collision.gameObject.CompareTag("ResultArea"))
        {
            m_spriteRenderer.sprite = m_defaltSprite;
        }
    }
}
