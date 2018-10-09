using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using Mono.Data.Sqlite;


public class ScoreManager : MonoBehaviour {

    private string connectionString;
    private List<int> scores = new List<int>();
    public GameObject scorePrefab;
    public Transform scoreParent;
	// Use this for initialization
	void Start () {
        connectionString = "URI=file:" + Application.dataPath + "/gogofishDB.sqlite";
        ShowScores();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void ShowScores()
    {
        GetScores();
        for(int i = 0; i<10; i++)
        {
            GameObject tmpObject = Instantiate(scorePrefab);

            int tmpScore = i<scores.Count?scores[i]:0;
            tmpObject.GetComponent<RankScript>().SetScore(tmpScore.ToString(), "#" + (i + 1).ToString());
            tmpObject.transform.SetParent(scoreParent);
        }
    }
    private void DeleteScores()
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "DELETE FROM scores";

                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
                dbConnection.Close();
            }
        }
    }
    private void GetScores(){
        scores.Clear();
        using (IDbConnection dbConnection = new SqliteConnection(connectionString)) {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "SELECT score FROM scores ORDER BY score DESC";

                dbCmd.CommandText = sqlQuery;

                using (IDataReader reader = dbCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        scores.Add(reader.GetInt32(0));
                    }
                    dbConnection.Close();
                    reader.Close();
                }
            }
        }
    }
}
