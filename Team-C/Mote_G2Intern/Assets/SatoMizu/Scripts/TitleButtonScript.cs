using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleButtonScript : MonoBehaviour {

    private SpriteRenderer m_spriteRender; 

    // Use this for initialization
    void Start () {
        m_spriteRender = GetComponent<SpriteRenderer>();
        var color = m_spriteRender.color;
        color.a = 0.5f;
        m_spriteRender.color = color;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}