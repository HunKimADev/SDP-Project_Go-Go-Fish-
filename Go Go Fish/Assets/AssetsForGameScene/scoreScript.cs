using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreScript : MonoBehaviour {
    Text scoreText;
    int score = 1950;
    int scoreCount = 0;

    // Use this for initialization
    void Start () {
        scoreText = GetComponent<Text>();

    }
	
	// Update is called once per frame
	void Update () {

        if(GameObject.Find("fish") != null)
        {
            scoreCount++;
            scoreText.text = "Year: " + score;

            if (scoreCount == 60)
            {
                scoreCount = 0;
                score++;
            }
        }

    }
}
