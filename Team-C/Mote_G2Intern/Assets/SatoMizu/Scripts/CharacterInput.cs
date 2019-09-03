using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class CharacterInput : MonoBehaviour {
    private Vector2 m_cursorPos;                         // カーソルのスクリーン座標
    private float angle;
    private Transform m_obj;      // キャラクター

    // Use this for initialization
    void Start () {
        m_obj = transform;      // transformを格納
        m_cursorPos.Set(0.0f, 0.0f);
        angle = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {
        // カーソルのスクリーン座標更新
        Vector3 screenPos = Input.mousePosition;
        // スクリーン座標をワールド座標に変換
        screenPos = Camera.main.ScreenToWorldPoint(screenPos);
        // カーソル座標更新
        m_cursorPos = new Vector2(screenPos.x, screenPos.y);

        // キャラクターの座標更新
        Vector2 characterPosition = new Vector2(m_obj.position.x, m_obj.position.y);

        // キャラクター座標とカーソル座標からベクトル生成
        Vector3 cursolVector = -(characterPosition - m_cursorPos);
        cursolVector = cursolVector.normalized;

        // ベクトルのatanから角度計算
        angle = (Mathf.Atan2(cursolVector.y, cursolVector.x) * Mathf.Rad2Deg) - 90.0f;

        // objct回転
        m_obj.transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle);

        // デバッグ用
#if DEBUG   
        if (Input.GetKey(KeyCode.Space)) Debug.Log(m_cursorPos);    // SPACE : カーソル座標
        if (Input.GetKey(KeyCode.A))       Debug.Log(cursolVector);     // A : カーソルのベクトル
        if (Input.GetKey(KeyCode.D))       Debug.Log(angle);              // D : 角度
#endif
    }
}
