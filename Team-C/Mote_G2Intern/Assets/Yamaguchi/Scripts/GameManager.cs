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

        m_CreateLover = GetComponent<IniCreateLover>();

        m_CreateLover.Init();

        m_CanPut = true;
    }

    void Start()
    {
        m_loverMgr = LoverManager.Instance;
    }

    // Update is called once per frame
    void Update () {
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
