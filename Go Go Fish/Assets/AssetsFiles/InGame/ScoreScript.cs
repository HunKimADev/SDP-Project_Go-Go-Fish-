using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Data;
using Mono.Data.Sqlite;

public class ScoreScript : MonoBehaviour {

    private string connectionString;
    Text scoreText;
    int score = 1950;
    int goBackTimer = 300;
    int scoreCount = 0;


    private void InsertScore(int newScore)
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = String.Format("INSERT INTO scores(score) VALUES(\"{0}\")", newScore);

                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
                dbConnection.Close();
            }
        }
    }

    // Use this for initialization
    void Start ()
    {
        connectionString = "URI=file:" + Application.dataPath + "/gogofishDB.sqlite";
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
            scoreText.text += "\n    FINAL YEAR (SCORE): " + score;
            scoreText.text += "\n                GAME OVER";
            scoreText.text += "\nWe go back to main (title) page in: " + goBackTimer/60;
            goBackTimer--;

            if(goBackTimer < 0)
            {

                InsertScore(score);
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}
