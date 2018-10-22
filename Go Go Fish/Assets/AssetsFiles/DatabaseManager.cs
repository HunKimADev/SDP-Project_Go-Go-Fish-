using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

#if UNITY_STANDALONE_WIN
using System.Data;
using Mono.Data.Sqlite;
#endif



public class DatabaseManager : MonoBehaviour {

    private string connectionString;
    // Use this for initialization
    void Start () {

        connectionString = "URI=file:" + Application.dataPath + "/gogofishDB.sqlite";
        #if UNITY_STANDALONE_WIN
        CreateTable();
        #endif

    }


    // Update is called once per frame
    void Update () {
		
	}

#if UNITY_STANDALONE_WIN
    private void CreateTable()
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "CREATE TABLE IF NOT EXISTS scores(" +
                    "score_ID INTEGER PRIMARY KEY," +
                    "score INTEGER NOT NULL," +
                    "date DATETIME NOT NULL DEFAULT CURRENT_DATE); ";

                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
                dbConnection.Close();
            }
        }

    }
#endif
}
