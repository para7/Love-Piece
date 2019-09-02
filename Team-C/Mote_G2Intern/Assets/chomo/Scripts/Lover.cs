using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lover : MonoBehaviour
{
    private LoverMover _loverMover;

    [SerializeField] private float m_moveSpeed;

    //呼び出し時に方向を代入させる
    [HideInInspector] public Vector2 m_moveDirection = Vector2.right;

    private void Awake()
    {
        _loverMover = new LoverMover(GetComponent<Rigidbody2D>());
    }

    private void Start()
    {
        LoverManager.Instance.AddList(this);
    }

    private void LoverUpdate()
    {
        _loverMover.Move(m_moveDirection * m_moveSpeed);
    }

    #region テスト用
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var direction = collision.gameObject.transform.position
                           - transform.position;

            m_moveDirection = direction.normalized;
        }
    }
    */
    #endregion

}
