using System.Collections.Generic;
using UnityEngine;

public class LoverManager : MonoBehaviour {
    public static LoverManager Instance;

    List<Lover> m_Lovers;

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

    public void AddList(Lover _Lover)
    {
        m_Lovers.Add(_Lover);
    }
    // Update is called once per frame
    void Update () {
		
	}
}
