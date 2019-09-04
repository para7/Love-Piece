using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreEvaluation : MonoBehaviour {

    [SerializeField] private Text m_Text;
    [SerializeField] private int m_MaxScore;

	void Start () {
        Evaluation(ScoreCounter.m_Score);
	}
	
    private void Evaluation(int score)
    {
        //設定した最大値に応じて分岐
        var divisionValue = m_MaxScore / 4;

        if (score >= m_MaxScore)
            m_Text.text = "ハリウッドスター級イケメン";
        else if (score >= divisionValue*3)
            m_Text.text = "イケメン";
        else if (score >= divisionValue*2)
            m_Text.text = "凡人";
        else
            m_Text.text = "ブス";
    }
}
