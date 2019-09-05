using System.Collections.Generic;
using UnityEngine;

public class LoverManager : MonoBehaviour {
    public static LoverManager Instance;

    List<Lover> m_Lovers = new List<Lover>();

    private bool m_CompleteLoverStop;

    private GameManager m_game;

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
        m_game = GameManager.Instance;
    }

    public void AddList(Lover _Lover)
    {
        m_Lovers.Add(_Lover);
    }

    public void RemoveList(Lover _lover)
    {
        m_Lovers.Remove(_lover);
    }

    // Update is called once per frame
    public void AllUpdate ()
    {
        if (m_CompleteLoverStop)
        {
            return;
        }

		foreach(var lover in m_Lovers)
        {
            lover.LoverUpdate();
        }
	}

    public void AllStop()
    {
        foreach(var lover in m_Lovers)
        {
            lover.LoverAllStop();
        }

        m_CompleteLoverStop = true;
    }
}
