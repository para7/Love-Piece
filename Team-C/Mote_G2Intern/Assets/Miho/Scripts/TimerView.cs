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
        // m_TimeCounter.OnTimeChanged.Subscribe(time => m_CounterText.text = "残り時間:"+time.ToString());
        StartCoroutine(StartTimeCount());
    }
	
    //この関数を読んでからLoverが動くようにする
    private IEnumerator StartTimeCount()
    {
        int countTime = 3;

        yield return new WaitForSeconds(2f);

        while (countTime > 0)
        {
            m_CounterText.text = countTime.ToString();
            countTime--;
            yield return new WaitForSeconds(1f);
        }

        m_CounterText.text = "スタート";

        yield return new WaitForSeconds(1f);

        m_TimeCounter.OnTimeChanged.Subscribe(time => m_CounterText.text = "残り" + time.ToString() + "秒");

        StartCoroutine(m_TimeCounter.TimerCoroutine());
    }
}
