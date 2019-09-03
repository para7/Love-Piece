using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScoreCounter : MonoBehaviour {

    public static int m_PlayerScore = 0;

    public static int GetCountPoint(int point) {
        m_PlayerScore+=point;
        return m_PlayerScore;
    }
}
