using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class TimerCounter : MonoBehaviour {

    private Subject<int> timerSubject = new Subject<int>();

    public IObservable<int> OnTimeChanged { get { return timerSubject; } }

    private void Start()
    {
        StartCoroutine(TimerCoroutine());
    }

    IEnumerator TimerCoroutine()
    {
        var time = 10;
        while (time > 0)
        {
            time--;
            //イベントを発行
            timerSubject.OnNext(time);
            yield return new WaitForSeconds(1);
        }
        FadeManager.Instance.LoadScene("ResultScene", 2.0f);
    }

}
