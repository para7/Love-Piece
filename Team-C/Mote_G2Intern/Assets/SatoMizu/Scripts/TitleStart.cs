using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleStart : MonoBehaviour {

    [SerializeField] GameObject m_Character;
    [SerializeField] GameObject m_StartButton;
    [SerializeField] GameObject m_QuitButton;
    [SerializeField] GameObject m_SetsumeiButton;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKeyDown)
        {
            if(GameObject.Find("TitleLogo"))
            {
                Destroy(GameObject.Find("TitleLogo"));
            }
            else
            {
                Debug.Log("ロゴなし");
            }

            if(GameObject.Find("LoversImage"))
            {
                GameObject.Find("LoversImage").SetActive(false);
            }
            else
            {
                Debug.Log("LoversImageなし");
            }

            Destroy(gameObject);

            CreateInstance(m_Character);
            CreateInstance(m_StartButton);
            CreateInstance(m_QuitButton);
            CreateInstance(m_SetsumeiButton);
        }
    }

    private void CreateInstance(GameObject _createObject)
    {
        GameObject newobject = Instantiate(_createObject);
        newobject.name = _createObject.name;
    }
}
