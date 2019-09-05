using System.Collections;
using UnityEngine;
using UniRx;
using System;

public class TimerCounter : MonoBehaviour {

    private Subject<int> timerSubject = new Subject<int>();

    public IObservable<int> OnTimeChanged { get { return timerSubject; } }

    private int m_Time;

    private void Start()
    {
        /// <summary>
        /// GameManagerからTimerを設定する
        /// </summary>
        m_Time = GameManager.Instance.getGameTime;
    }

    public IEnumerator TimerCoroutine()
    {
        while (m_Time> 0)
        {
            m_Time--;
            timerSubject.OnNext(m_Time);
            yield return new WaitForSeconds(1f);
        }
        FadeManager.Instance.LoadScene("ResultScene", 2.0f);
    }

}
