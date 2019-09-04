using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneTransition : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        GetComponent<AudioManager>().AudioPlay(0);
    }

    private void Update()
    {
        if (Input.anyKey)
        {
            GetComponent<AudioManager>().AudioPlay(1);
            SceneManager.LoadScene("MainScene");
        }
    }

}
