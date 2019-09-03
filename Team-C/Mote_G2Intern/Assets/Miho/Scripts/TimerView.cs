using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class TimerView : MonoBehaviour {

    [SerializeField] private TimerCounter m_TimeCounter;
    [SerializeField] private Text m_CounterText;

    void Start()
    {
        m_TimeCounter.OnTimeChanged.Subscribe(time => m_CounterText.text = time.ToString());
    }
	
}
