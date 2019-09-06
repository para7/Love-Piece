using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreEvaluation : MonoBehaviour {

    [SerializeField] private Text m_Text;
    [SerializeField] private Slider m_HeartSlider;
    [SerializeField] private ParticleSystem m_ParticleSystem;
    private int m_EvalutionValue;

	void Start () {
        EvalutionChange(EvaluationScore(ScoreCounter.m_Score));
        m_HeartSlider.value = ScoreCounter.m_Score;
	}
	
    private int EvaluationScore(int score)
    {

        if (score>=2000)
            return 0;
        else if (score >= 1300)
            return 1;
        else if (score >= 600)
            return 2;
        else
            return 3;
    }

    //背景色変更、テキスト更新
    private void EvalutionChange(int evalutionValue)
    {
        switch (evalutionValue)
        {
            case 0:
                m_Text.text = "ハリウッドスター級イケメン";
                m_Text.fontSize = 61;
                ColorChange(253,234,37,230);
                ParticleChange(7.0f);
                break;

            case 1:
                m_Text.text = "イケメン";
                m_Text.fontSize = 95;
                ColorChange(114,255,86,230);
                ParticleChange(5.0f);
                break;

            case 2:
                m_Text.text = "凡人";
                m_Text.fontSize = 100;
                ColorChange(86,255,193,230);
                ParticleChange(2.0f);
                break;

            case 3:
                m_Text.text = "ブス";
                m_Text.fontSize = 100;
                ColorChange(50,57,174,230);
                ParticleChange(1.0f);
                break;
        }
    }

    //背景色変更 
    private void ColorChange(int R,int G,int B,int A)
    {
        Color newColor;
        newColor = new Color((float)R / 255,(float) G / 255,(float) B / 255,(float) A / 255);
        Camera.main.backgroundColor = newColor;
    }

    //背景のパーティクルの数変更
    private void ParticleChange(float value)
    {
        var mEmObj = m_ParticleSystem.emission;
        mEmObj.rateOverTime = new ParticleSystem.MinMaxCurve(value);
    }
}
