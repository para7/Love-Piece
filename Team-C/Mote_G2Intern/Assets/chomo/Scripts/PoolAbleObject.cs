using UnityEngine;
using System;
using UniRx;
using DG.Tweening;

public class PoolAbleObject : MonoBehaviour
{
    [SerializeField]private double m_finishTime = 2.0f;

    public IObservable<Unit> ShowScore(Vector3 position)
    {
        transform.position = position;

        transform.DOPunchScale(transform.localScale * 1.5f, 1f);
            
           //1秒後にエフェクトを止めて終了
        return Observable.Timer(TimeSpan.FromSeconds(1.0f))
                .ForEachAsync(_ => this.gameObject.SetActive(false));
    }
}
