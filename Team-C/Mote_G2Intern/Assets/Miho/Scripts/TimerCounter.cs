using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class TimerCounter : MonoBehaviour {

    private Subject<int> timerSubject = new Subject<int>();

    public IObservable<int> OnTimeChanged { get { return timerSubject; } }

    [SerializeField] private int m_Time;

    private void Start()
    {
        StartCoroutine(TimerCoroutine());
    }

    IEnumerator TimerCoroutine()
    {
        while (m_Time> 0)
        {
            m_Time--;
            timerSubject.OnNext(m_Time);
            yield return new WaitForSeconds(1);
        }
        FadeManager.Instance.LoadScene("ResultScene", 2.0f);
    }

}
