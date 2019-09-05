using UnityEngine;
using System;
using UniRx;
using DG.Tweening;
using UnityEngine.UI;

public class PoolAbleObject : MonoBehaviour
{
    [SerializeField]private double m_finishTime = 2.0f;

    private Canvas m_canvas;
    private RectTransform m_canvasRect;
    private RectTransform m_rectTransform;

    [SerializeField]private Vector2 m_offset = new Vector2(0, 1.5f);
    private void Start()
    {
        m_canvas = GetComponentInParent<Canvas>();
        m_canvasRect = m_canvas.GetComponent<RectTransform>();

        m_rectTransform = GetComponent<RectTransform>();
    }

    public IObservable<Unit> ShowScore(Vector3 position)
    {
        SetDiplayPosition(position);

        transform.DOPunchScale(transform.localScale * 1.5f, 1f);
            
           //1秒後にエフェクトを止めて終了
        return Observable.Timer(TimeSpan.FromSeconds(1.0f))
                .ForEachAsync(_ => this.gameObject.SetActive(false));
    }

    private void SetDiplayPosition(Vector2 targetPos)
    {
        switch (m_canvas.renderMode)
        {

            case RenderMode.ScreenSpaceOverlay:
                m_rectTransform.position = RectTransformUtility.WorldToScreenPoint(Camera.main, targetPos + m_offset);

                break;

            case RenderMode.ScreenSpaceCamera:
                Vector2 screenPos = RectTransformUtility.WorldToScreenPoint(Camera.main, targetPos + m_offset);
                Vector2 pos;

                RectTransformUtility.ScreenPointToLocalPointInRectangle(m_canvasRect, screenPos, Camera.main, out pos);
                m_rectTransform.localPosition = pos;
                break;

            case RenderMode.WorldSpace:
                m_rectTransform.LookAt(Camera.main.transform);

                break;
        }
    }
}
