using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleStart : MonoBehaviour {

    [SerializeField] GameObject m_Character;
    [SerializeField] GameObject m_StartButton;
    [SerializeField] GameObject m_QuitButton;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKeyDown)
        {
            Destroy(GameObject.Find("TitleLogo"));
            Destroy(gameObject);
            Instantiate(m_Character);
            Instantiate(m_StartButton);
            Instantiate(m_QuitButton);
        }
    }
}
