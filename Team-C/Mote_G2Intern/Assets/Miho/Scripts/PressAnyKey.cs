using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressAnyKey : MonoBehaviour {

    void Start()
    {
        this.GetComponent<AudioManager>().AudioPlay(0);
    }

    void Update () {
        PressSceneTransition("TitleScene");
	}

    private void PressSceneTransition(string scene)
    {
        if (Input.anyKey)
        {
            ScoreCounter.m_Score = 0;
            SceneManager.LoadScene(scene);
        }
    }
}
