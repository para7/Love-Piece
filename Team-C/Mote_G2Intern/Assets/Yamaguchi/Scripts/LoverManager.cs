using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoverManager : MonoBehaviour {
    public static LoverManager Instance;

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

    // Update is called once per frame
    void Update () {
		
	}
}
