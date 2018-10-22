using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerScript : MonoBehaviour {
    private LevelUp lup;
    private ScoreScript sc;
    //int speed = 10;
    //int score = 0;
    bool move = false;
    int difficultCounter = 0;
    float initialDifficult = 0.5f;
    float timer = 0f;
    int timeInitial = 0;

    // Use this for initialization
    void Start ()
    {
        lup = GameObject.FindGameObjectWithTag("diffUp").GetComponent<LevelUp>();
        sc = GameObject.FindGameObjectWithTag("stageUp").GetComponent<ScoreScript>();

        GameObject go = Resources.Load("Trash") as GameObject;
        GameObject go2 = Resources.Load("Seaweed") as GameObject;
        GameObject go3 = Resources.Load("Bomb") as GameObject;

        //go.name = "TrashDynamic";
        Instantiate(go).name = "TrashDynamic";
        Instantiate(go2).name = "SeaweedDynamic";
        Instantiate(go3).name = "BombDynamic";

        timeInitial = (int)Time.time;
    }
	
	// Update is called once per frame
	void Update () {

        if(difficultCounter == 10)
        {
            if(initialDifficult > 0.05f)
            {
                lup.runTimer();
                sc.stageUp();
                initialDifficult -= 0.05f;
            }

            difficultCounter = 0;
        }

        timer += ((int)Time.time) - timeInitial;

        if (timer >= initialDifficult && move == false)
        {
            move = true;
            timeInitial = ((int)Time.time);

            GameObject go = Resources.Load("Trash") as GameObject;
            GameObject go2 = Resources.Load("Seaweed") as GameObject;
            GameObject go3 = Resources.Load("Bomb") as GameObject;

            Instantiate(go).name = "TrashDynamic";
            Instantiate(go2).name = "SeaweedDynamic";
            Instantiate(go3).name = "BombDynamic";

            /*
            GameObject objectA = (GameObject) Resources.Load("Trash.png", typeof(GameObject));

            if(objectA == null)
            {
                GameObject obj = (GameObject)Instantiate(objectA, transform.right * -speed * Time.deltaTime, transform.rotation);
                obj.AddComponent<trashMove>();
            }
            */
        }
        else if(timer - timeInitial >= initialDifficult && move == true)
        {
            difficultCounter++;
            move = false;
            timeInitial = ((int)Time.time);
            
        }
        
        //if (move == true)
        //    transform.position += transform.right * -speed * Time.deltaTime;


	}
}
