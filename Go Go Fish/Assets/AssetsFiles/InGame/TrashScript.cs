using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashScript : MonoBehaviour {

    int speed = 10;
    int iRandom = 0;
    int iRandomScale = 0;

    // Use this for initialization
    void Start () {
        speed = (int)(Random.value * 10) + 1;
        iRandom = (int)(Random.value * 9);
        iRandomScale = (int)(Random.value * 3);
        
        transform.position = new Vector3(12f, (iRandom - 4) * 1.0f, 0f);
        transform.localScale += new Vector3(iRandomScale * 1.0f, iRandomScale * 1.0f, 0);
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
