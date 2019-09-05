using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressAnyKey : MonoBehaviour {
	
	void Update () {
        PressSceneTransition("TitleScene");
	}

    private void PressSceneTransition(string scene)
    {
        if (Input.anyKey)
            SceneManager.LoadScene(scene);
    }
}
