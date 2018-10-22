using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
#if UNITY_STANDALONE_WIN
using System.Data;
using Mono.Data.Sqlite;
#endif

public class ScoreScript : MonoBehaviour
{
    public AudioClip soundGameOver;
    private AudioSource sGameOver { get { return GetComponent<AudioSource>(); } }

    private string connectionString;
    Text scoreText;
    int score = 1950;
    int scoreInitial = 0;
    int stage = 1;
    int goBackTimer = -1;
    bool playOnce = true;

    #if UNITY_STANDALONE_WIN
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
    #endif

    public void stageUp()
    {
        stage++;
    }

    // Use this for initialization
    void Start ()
    {
        connectionString = "URI=file:" + Application.dataPath + "/gogofishDB.sqlite";
        scoreText = GetComponent<Text>();
        scoreInitial = (int)Time.time;

        gameObject.AddComponent<AudioSource>();
        sGameOver.clip = soundGameOver;
        sGameOver.playOnAwake = false;
    }
	
	// Update is called once per frame
	void Update () {

        if(GameObject.Find("FishPlayer") != null)
        {
            score = ((int)Time.time) + 1950 - scoreInitial;
            scoreText.text = "Year: " + score;
            scoreText.text += "\nStage: " + stage;
        }
        else if(goBackTimer == -1)
        {
            goBackTimer = (int)Time.time + 5;
        }
        else
        {
            if(playOnce == true)
            {
                sGameOver.PlayOneShot(soundGameOver);
                playOnce = false;
            }

            if (((int)Time.time) <= goBackTimer)
            {
                scoreText.text = "Year: " + score;
                scoreText.text += "\n\nYear of the Dead - " + score;
                scoreText.text += "\nGAME OVER";
                scoreText.text += "\nWe go back to main (title) page in: " + (goBackTimer - ((int)Time.time));
            }
            else if(((int)Time.time) > goBackTimer)
            {
                #if UNITY_STANDALONE_WIN
                InsertScore(score);
                #endif
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}
