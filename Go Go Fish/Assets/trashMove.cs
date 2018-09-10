using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trashMove : MonoBehaviour {

    int speed = 10;
    int iRandom = 0;
    int iRandomScale = 0;

    // Use this for initialization
    void Start () {
        speed = (int) (Random.value * 10) + 1;
        iRandom = (int) (Random.value * 9);
        iRandomScale = (int)(Random.value * 3);

        if (iRandom == 0)
        {
            transform.position = new Vector3(12f, 4f, 0f);
        }
        else if (iRandom == 1)
        {
            transform.position = new Vector3(12f, 3f, 0f);
        }
        else if (iRandom == 2)
        {
            transform.position = new Vector3(12f, 2f, 0f);
        }
        else if (iRandom == 3)
        {
            transform.position = new Vector3(12f, 1f, 0f);
        }
        else if (iRandom == 4)
        {
            transform.position = new Vector3(12f, 0f, 0f);
        }
        else if (iRandom == 5)
        {
            transform.position = new Vector3(12f, -1f, 0f);
        }
        else if (iRandom == 6)
        {
            transform.position = new Vector3(12f, -2f, 0f);
        }
        else if (iRandom == 7)
        {
            transform.position = new Vector3(12f, -3f, 0f);
        }
        else if (iRandom == 8)
        {
            transform.position = new Vector3(12f, -4f, 0f);
        }

        if (iRandomScale == 0)
        {
            //do nothing
        }
        else if (iRandomScale == 1)
        {
            transform.localScale += new Vector3(1f, 1f, 0);
        }
        else if (iRandomScale == 2)
        {
            transform.localScale += new Vector3(2f, 2f, 0);
        }

    }
	
	// Update is called once per frame
	void Update () {
        moveTrash();
        checkDestroy();
	}

    void moveTrash()
    {
        transform.position += transform.right * -speed * Time.deltaTime;
    }

    void checkDestroy()
    {
        if(transform.position.x <= -12.0f)
        {
            Destroy(this.gameObject);
        }

    }
}
