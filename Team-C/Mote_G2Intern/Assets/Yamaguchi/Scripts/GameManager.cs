using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;

    private LoverManager m_loverMgr;

    private IniCreateLover m_CreateLover;

    private bool m_CanPut;

    [HideInInspector] public bool m_InGame { get; private set; }

    [SerializeField] private int m_gameTime = 15;
    public int getGameTime {
        get { return m_gameTime; }
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }


        /// <summary>
        /// フレームレートを60に固定
        /// </summary>
        Application.targetFrameRate = 60;

        m_CreateLover = GetComponent<IniCreateLover>();

        Observable.Timer(TimeSpan.FromSeconds(5.0)).Subscribe(_ =>
        {
            m_CreateLover.Init();

            m_CanPut = true;

            m_InGame = true;
        }).AddTo(this);
    }

    void Start()
    {
        m_loverMgr = LoverManager.Instance;

        /// <summary>
        /// ゲームタイマーを終了する処理
        /// (フェードアウト2秒+カウントダウン3秒追加)
        /// </summary>
        Observable.Timer(TimeSpan.FromSeconds
            ((double)getGameTime+6)).Subscribe(_ =>
        {
            m_InGame = false;

            m_loverMgr.AllStop();
        }).AddTo(this);
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (!m_InGame)
        {
            return;
        }

        m_loverMgr.AllUpdate();

        if (!m_CanPut)
        {
            return;
        }

        m_CreateLover.Init();
        m_CanPut = false;

        Observable.Timer(TimeSpan.FromSeconds(1.0)).Subscribe(_ =>
        {
            m_CanPut = true;
        }).AddTo(this);
	}
}
