using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreScript : MonoBehaviour {
    Text scoreText;
    int score = 0;

    // Use this for initialization
    void Start () {
        scoreText = GetComponent<Text>();

    }
	
	// Update is called once per frame
	void Update () {
        score++;
        scoreText.text = "Score: " + score;
    }
}
