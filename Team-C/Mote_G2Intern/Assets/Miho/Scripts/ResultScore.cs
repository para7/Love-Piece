using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScore : MonoBehaviour {

    [SerializeField] Text m_ScoreText;
	
	void Start ()
    {
        m_ScoreText.text = "Score:" + ScoreCounter.m_Score.ToString();
    }
	
	
}
