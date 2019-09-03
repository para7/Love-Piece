using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInput : MonoBehaviour {

    private Vector2 m_cursorPos;                         // カーソルのスクリーン座標
    [SerializeField] private GameObject m_obj;      // キャラクター

    // Use this for initialization
    void Start () {
        m_cursorPos.Set(0.0f, 0.0f);

    }
	
	// Update is called once per frame
	void Update () {
        // カーソルのスクリーン座標更新
        Vector3 screenPos = Input.mousePosition;
        // スクリーン座標をワールド座標に変換
        screenPos = Camera.main.ScreenToWorldPoint(screenPos);
        // カーソル座標更新
        m_cursorPos = new Vector2(screenPos.x, screenPos.y);

        if(Input.GetKey(KeyCode.Space))
        {
            Debug.Log(m_cursorPos);
        }

        // キャラクターの座標更新
        Vector2 characterPosition = new Vector2(m_obj.transform.position.x, m_obj.transform.position.y);

        // キャラクター座標とカーソル座標からベクトル生成
        Vector3 vector = -(characterPosition - m_cursorPos);
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log(vector);
        }

    }
}
