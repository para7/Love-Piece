using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class Lover : MonoBehaviour
{
    private LoverMover _loverMover;

    [SerializeField] private float m_moveSpeed = 100f;

    [SerializeField] private double m_stopTime = 1.5;

    private bool m_isStopped; 

    //呼び出し時に方向を代入させる
    [HideInInspector] public Vector2 m_moveDirection = Vector2.right;

    private void Awake()
    {
        _loverMover = new LoverMover(GetComponent<Rigidbody2D>());
    }

    private void Start()
    {
        LoverManager.Instance.AddList(this);

        m_isStopped = false;
    }

    private void LoverUpdate()
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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var direction = collision.gameObject.transform.position
                           - transform.position;

            m_moveDirection = direction.normalized;

            return;
        }

        /// <summary>
        /// プレイヤーに一定の距離近づいたら、
        /// Loverの動きをしばらく止める
        /// </summary>
        if (collision.gameObject.CompareTag("Stop"))
        {
            m_isStopped = true;

            /// <summary>
            /// m_stopTime秒経ったらfalseにする
            /// </summary>
            Observable.Timer(TimeSpan.FromSeconds(m_stopTime)).Subscribe(_ =>
            {
                m_isStopped = false;
            }).AddTo(this);
        }
    }
}
