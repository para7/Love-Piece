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

    [SerializeField]private RectTransform m_rectTransform;

    [SerializeField]private Text m_text;

    [SerializeField]private Vector2 m_offset = new Vector2(0, 1.5f);

    public void Init(Canvas canvas)
    {
        m_canvas = canvas;
        m_canvasRect = m_canvas.GetComponent<RectTransform>();
    } 

    public IObservable<Unit> ShowScore(Vector3 position, int score)
    {
        ScoreCounter.GetScore(score);

        SetDiplayPosition(position);

        SetScoreProperty(score);

        transform.DOPunchScale(transform.localScale * 1.5f, 1f);
            
           //1秒後にエフェクトを止めて終了
        return Observable.Timer(TimeSpan.FromSeconds(m_finishTime))
                .ForEachAsync(_ => this.gameObject.SetActive(false));
    }

   
    private void SetDiplayPosition(Vector2 targetPos)
    {
        switch (m_canvas.renderMode)//レンダーモードによって変える
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

    private void SetScoreProperty(int score)　//Loverごとの得点と色を設定
    {
        string scoreText = "";

        if (score >= 0)
        {
            scoreText += "+";
            m_text.color = Color.red;
        }
        else
        {
            m_text.color = Color.blue;
        }

        scoreText += score.ToString();

        m_text.text = scoreText;
    }
}
