using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotation : MonoBehaviour {

    [SerializeField] private float m_rotateSpeed;
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Rotate(new Vector3(0.0f, 0.0f, m_rotateSpeed));
	}
}
