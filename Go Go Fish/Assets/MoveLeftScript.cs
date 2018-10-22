using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(-Vector3.right * 3.0f * Time.deltaTime);

        if (transform.position.x <= -20.0f)
        {
            transform.position = new Vector3(27.38f, gameObject.transform.position.y, gameObject.transform.position.z);
        }
    }
}
