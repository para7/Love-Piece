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
        var createNum = Random.Range(10, 21);
        /*
        for (var makeCount = 0; makeCount <= createNum; ++makeCount)
        {
        }
        */
        var loverObj = Instantiate(
            m_LoverPrefab[Random.Range(0, m_LoverPrefab.Length)])
            .GetComponent<Lover>();

        loverObj.iniPos = Random.Range(0, 5);
    }
}
