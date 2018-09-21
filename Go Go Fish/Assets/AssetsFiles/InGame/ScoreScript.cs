using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour {
    Text scoreText;
    int score = 1950;
    int goBackTimer = 300;
    int scoreCount = 0;

    // Use this for initialization
    void Start () {
        scoreText = GetComponent<Text>();

    }
	
	// Update is called once per frame
	void Update () {

        if(GameObject.Find("FishPlayer") != null)
        {
            scoreCount++;
            scoreText.text = "Year: " + score;

            if (scoreCount == 60)
            {
                scoreCount = 0;
                score++;
            }
        }
        else
        {
            scoreText.text = "Year: " + score;
            scoreText.text += "\n\n            FINAL YEAR (SCORE): " + score;
            scoreText.text += "\n                        GAME OVER";
            scoreText.text += "\n      We go back to main (title) page in: " + goBackTimer/60;
            goBackTimer--;

            if(goBackTimer < 0)
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}
