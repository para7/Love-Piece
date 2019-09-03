using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetting : MonoBehaviour {

    private SpriteRenderer m_spriteRenderer;    //  2Dオブジェクト
    [SerializeField] private float alpha;   //  α値

    // Use this for initialization
    void Start () {
        this.m_spriteRenderer = GetComponent<SpriteRenderer>();
        this.m_spriteRenderer.color = new Color(1, 1, 1, alpha);
	}
}
