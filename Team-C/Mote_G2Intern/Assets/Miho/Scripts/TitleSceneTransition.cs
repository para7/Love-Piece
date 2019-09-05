using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSceneTransition : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        this.GetComponent<AudioManager>().AudioPlay(0);
    }
}