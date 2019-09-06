using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IniCreateLover : MonoBehaviour {
    enum moveDir
    {
        up,
        down,
        left,
        right
    };

    [SerializeField] GameObject[] m_LoverPrefab;

    /// <summary>
    /// GameManagerから呼び出す
    /// </summary>
    public void Init()
    {
        /// <summary>
        /// Loverの数を指定
        /// 10~20
        /// </summary>
        var randomNum = Random.Range(0, 11);
        var createLoverNum = 0;
        if (randomNum <= 1)
        {
            createLoverNum = 0;
        }
        else if (randomNum <= 3)
        {
            createLoverNum = 1;
        }
        else if (randomNum <= 5)
        {
            createLoverNum = 2;
        }
        else if (randomNum <= 7)
        {
            createLoverNum = 3;
        }
        else if (randomNum <= 8)
        {
            createLoverNum = 4;
        }
        else
        {
            createLoverNum = 5;
        }

        var loverObj = Instantiate(
            m_LoverPrefab[createLoverNum])
            .GetComponent<Lover>();

        loverObj.iniPos = Random.Range(0, 5);
    }
}
