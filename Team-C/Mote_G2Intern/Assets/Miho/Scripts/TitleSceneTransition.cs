using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSceneTransition : MonoBehaviour {

    [SerializeField] GameObject m_BG1;

    private void Awake()
    {
        GameObject newObject = Instantiate(m_BG1);
        newObject.name = m_BG1.name;
        newObject.SetActive(true);
    }
    // Use this for initialization
    void Start()
    {
        this.GetComponent<AudioManager>().AudioPlay(0);
    }
}