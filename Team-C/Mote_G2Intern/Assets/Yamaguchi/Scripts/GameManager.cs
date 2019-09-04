using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;

    private LoverManager m_loverMgr;

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
    }

    void Start()
    {
        m_loverMgr = LoverManager.Instance;
    }

    // Update is called once per frame
    void Update () {
        m_loverMgr.AllUpdate();
	}
}
