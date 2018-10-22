using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RealTimeStatusScript : MonoBehaviour {

    Text livesText;
    private FishScript fishLivesChecker;

	// Use this for initialization
	void Start ()
    {
        fishLivesChecker = GameObject.Find("FishPlayer").GetComponent<FishScript>();
        livesText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        {
            if(fishLivesChecker.getLives() > 1)
            {
                livesText.text = "Lives: " + fishLivesChecker.getLives();
            }
            else
            {
                livesText.text = "Life: " + fishLivesChecker.getLives();
            }

            livesText.text += "\nEnergy: " + fishLivesChecker.getEnergy();
        }
	}
}
