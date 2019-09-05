using UnityEngine;

public class ScoreCounter : MonoBehaviour{

    public static int m_Score = 0;

    public static void GetScore(int point)
    {
        m_Score += point;
    }

    void OnLoder()
    {
        DontDestroyOnLoad(this);
    }
}
