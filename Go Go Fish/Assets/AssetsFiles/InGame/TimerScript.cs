using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerScript : MonoBehaviour {
    //int speed = 10;
    //int score = 0;
    bool move = false;
    int difficultCounter = 0;
    float initialDifficult = 0.5f;
    float timer = 0f;

    // Use this for initialization
    void Start () {
        GameObject go = Resources.Load("Trash") as GameObject;
        //go.name = "TrashDynamic";
        Instantiate(go).name = "TrashDynamic";
    }
	
	// Update is called once per frame
	void Update () {

        if(difficultCounter == 15)
        {
            if(initialDifficult > 0.2f)
                initialDifficult -= 0.05f;

            difficultCounter = 0;
        }

        timer += Time.deltaTime;

        if (timer >= initialDifficult && move == false)
        {
            move = true;
            timer = 0f;

            GameObject go = Resources.Load("Trash") as GameObject;
            Instantiate(go).name = "TrashDynamic";

            /*
            GameObject objectA = (GameObject) Resources.Load("Trash.png", typeof(GameObject));

            if(objectA == null)
            {
                GameObject obj = (GameObject)Instantiate(objectA, transform.right * -speed * Time.deltaTime, transform.rotation);
                obj.AddComponent<trashMove>();
            }
            */
        }
        else if(timer >= initialDifficult && move == true)
        {
            difficultCounter++;
            move = false;
            timer = 0f;
        }
        
        //if (move == true)
        //    transform.position += transform.right * -speed * Time.deltaTime;


	}
}
