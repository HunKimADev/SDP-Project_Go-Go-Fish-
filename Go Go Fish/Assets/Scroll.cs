using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour {

    public float speed = 0.1f;
    float targetOffset;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        targetOffset = Time.time * speed;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(targetOffset, 0);
    }
}
