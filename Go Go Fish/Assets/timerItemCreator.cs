using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timerItemCreator : MonoBehaviour {
    bool move = false;
    int speed = 10;
    float timer = 0f;

    // Use this for initialization
    void Start () {
        GameObject go = Resources.Load("Trash") as GameObject;
        //go.name = "TrashDynamic";
        Instantiate(go).name = "TrashDynamic";

		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if (timer >= 0.5f && move == false)
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
        else if(timer >= 0.5f && move == true)
        {
            move = false;
            timer = 0f;
        }
        
        //if (move == true)
        //    transform.position += transform.right * -speed * Time.deltaTime;


	}
}
