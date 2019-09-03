using UnityEngine;
using UniRx;
using System;

public class Lover : MonoBehaviour
{
    private LoverMover _loverMover;

    [SerializeField] private float m_moveSpeed = 100f;

    [SerializeField] private double m_stopTime = 1.5;

    [SerializeField] private int m_scoreValue = 1;

    private bool m_isStopped; 

    //呼び出し時に方向を代入させる
    [HideInInspector] public Vector2 m_moveDirection = Vector2.right;

    private Vector3 m_PlayerPos = new Vector3(0, 0, 0);

    private void Awake()
    {
        _loverMover = new LoverMover(GetComponent<Rigidbody2D>());
    }

    private void Start()
    {
        LoverManager.Instance.AddList(this);

        m_isStopped = false;
    }

    public void LoverUpdate()
    {
        /// <summary>
        /// 停止フラグがtrueの場合、
        /// 早期リターン
        /// </summary>
        if (m_isStopped)
        {
            return;
        }

        _loverMover.Move(m_moveDirection * m_moveSpeed);
    }

    private void SetMoveDirection(bool isApproach)
    {
        var direction = Vector3.zero;

        if (isApproach)
        {
            direction = m_PlayerPos - transform.position;
        }
        else
        {
            direction = transform.position - m_PlayerPos;
        }

        m_moveDirection = direction.normalized;
    }

    #region 当たり判定
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /// <summary>
        /// プレイヤーに一定の距離近づいたら、
        /// Loverの動きをしばらく止める
        /// </summary>
        if (collision.gameObject.CompareTag("Stop"))
        {            
            _loverMover.Move(Vector2.zero);

            m_isStopped = true;
            /// <summary>
            /// m_stopTime秒経ったらfalseにする
            /// </summary>
            Observable.Timer(TimeSpan.FromSeconds(m_stopTime)).Subscribe(_ =>
            {
                m_isStopped = false;
                SetMoveDirection(isApproach: false);
            }).AddTo(this);
        }

        if (collision.gameObject.CompareTag("ResultArea"))
        {
            ScoreCounter.GetScore(m_scoreValue);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && 
            m_isStopped == false)
        {
            SetMoveDirection(isApproach: true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SetMoveDirection(isApproach: false);
        }
    }
    #endregion
}
