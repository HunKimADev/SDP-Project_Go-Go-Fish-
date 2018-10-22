using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUp : MonoBehaviour {
    bool run;
    int initTimer;
    int currentTimer;
    int flash;
    bool playOnce = true;

    private AudioSource sNextStage { get { return GetComponent<AudioSource>(); } }
    public AudioClip soundNextStage;

    public void runTimer()
    {
        run = true;
    }

	// Use this for initialization
	void Start ()
    {
        gameObject.transform.localScale = new Vector3(0, 0, 0);
        run = false;

        gameObject.AddComponent<AudioSource>();
        sNextStage.clip = soundNextStage;
        sNextStage.playOnAwake = false;
    }
	
	// Update is called once per frame
	void Update () {
        if(run == true)
        {
            initTimer = (int) Time.time;
            currentTimer = initTimer;
            flash = 2;
            run = false;
        }

        if(flash > 0)
        {
            if(flash % 2 == 0)
            {
                if (playOnce == true)
                {
                    sNextStage.PlayOneShot(soundNextStage);
                    playOnce = false;
                }

                gameObject.transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                playOnce = true;
                gameObject.transform.localScale = new Vector3(0, 0, 0);
            }
        }

        if(initTimer + 1 < currentTimer)
        {
            flash--;
            initTimer = (int)Time.time;
            currentTimer = initTimer;
        }

        currentTimer = (int)Time.time;

        if (GameObject.Find("FishPlayer") == null)
        {
            gameObject.transform.localScale = new Vector3(0, 0, 0);
        }

    }
}
