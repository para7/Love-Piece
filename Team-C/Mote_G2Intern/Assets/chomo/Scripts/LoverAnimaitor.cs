using UnityEngine;
using DG.Tweening;

public class LoverAnimaitor : MonoBehaviour
{
    [SerializeField] private Sprite m_defaltSprite;

    [SerializeField] private Sprite m_fallInLoveSprite;

    private SpriteRenderer m_spriteRenderer;

    private ParticleSystem m_particleSystem;

    private Tween m_jumpTween;

    private bool m_isResultArea;

    private void Awake()
    { 
        m_spriteRenderer = GetComponent<SpriteRenderer>();

        m_particleSystem = GetComponent<ParticleSystem>();

        InitializeJumpTween();
    }

    private void Start()
    {
        m_spriteRenderer.sprite = m_defaltSprite;

        //InitializeJumpTween();

        m_isResultArea = false;
    }

    private void InitializeJumpTween()
    {
        m_jumpTween = transform.DOLocalMoveY(0.5f, 0.5f)
                .SetRelative()
                .SetLoops(-1, LoopType.Yoyo);
        m_jumpTween.Pause();
    }

    #region　当たり判定
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!m_jumpTween.IsPlaying() &&
             collision.gameObject.CompareTag("Stop"))
        {
            m_jumpTween.Restart();
        }

        if (collision.gameObject.CompareTag("ResultArea"))
        {
            m_isResultArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {   

        if (collision.gameObject.CompareTag("ResultArea"))
        {
            m_isResultArea = false;

            if (m_jumpTween.IsPlaying())
            {
                m_jumpTween.Pause();
            }
        }

        if (collision.gameObject.CompareTag("Player") ||
            collision.gameObject.CompareTag("ResultArea"))
        {
            if (!m_isResultArea)
            {
                m_spriteRenderer.sprite = m_defaltSprite;
                m_particleSystem.Stop();
            }
        }
    }
    #endregion
}
