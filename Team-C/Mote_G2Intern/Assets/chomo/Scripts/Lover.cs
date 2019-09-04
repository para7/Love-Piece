using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using System;

public class Lover : MonoBehaviour
{
    private LoverMover _loverMover;

    [SerializeField] private float m_moveSpeed = 100f;

    [SerializeField] private float m_approachSpeed = 100f;

    [SerializeField] private double m_stopTime = 1.5;

    [SerializeField] private int m_scoreValue = 1;

    private bool m_isStopped;

    private bool m_isArea;

    //呼び出し時に方向を代入させる
    [HideInInspector] public Vector2 m_moveDirection { get; set; }

    [HideInInspector] public int iniPos;

    private Vector3 m_PlayerPos = new Vector3(0, 0, 0);

    private void Awake()
    {
        _loverMover = new LoverMover(GetComponent<Rigidbody2D>());
    }

    private void Start()
    {
        switch(iniPos)
        {
            case 0:
                m_moveDirection = new Vector2(1.0f, .0f);
                transform.position = new Vector3(-7.5f, 4.0f, 0);
                break;
            case 1:
                m_moveDirection = new Vector2(-1.0f, .0f);
                transform.position = new Vector3(7.5f, -4.0f, 0);
                break;
            case 2:
                m_moveDirection = new Vector2(.0f, -1.0f);
                transform.position = new Vector3(5.3f, 5.8f, 0);
                break;
            default:
                m_moveDirection = new Vector2(.0f, 1.0f);
                transform.position = new Vector3(-5.3f, -5.8f, 0);
                break;
        }
        
        LoverManager.Instance.AddList(this);

        m_moveDirection *= m_moveSpeed;

        m_isStopped = false;
        m_isArea = false;
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

        _loverMover.Move(m_moveDirection);
    }

    private void SetMoveDirection(bool isApproach)
    {
        var direction = m_PlayerPos - transform.position;
        
        if(isApproach)
        {
            m_moveDirection = direction.normalized * m_approachSpeed;
            return;
        }

        direction *= -1;
        m_moveDirection = direction.normalized * m_moveSpeed;
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
            m_isArea = true;
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
        if (!collision.gameObject.CompareTag("Player"))
        {
            return;
        }

        if (m_isStopped)
        {
            return;
        }

        if (m_isArea)
        {
            return;
        }

        SetMoveDirection(isApproach: true);
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SetMoveDirection(isApproach: false);
        }

        if (collision.gameObject.CompareTag("Stop"))
        {
            m_isArea = false;
        }
    }

    #endregion
}
