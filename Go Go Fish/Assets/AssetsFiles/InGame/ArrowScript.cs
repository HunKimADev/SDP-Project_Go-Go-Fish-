using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ArrowScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
    private FishScript fishMoveScript;
    bool buttonPressed = false;

    // Use this for initialization
    void Start () {
        fishMoveScript = GameObject.FindGameObjectWithTag("Player").GetComponent<FishScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonPressed == true && GameObject.Find("FishPlayer") != null)
        {
            if(this.gameObject.name == "ButtonLeft")
            {
                fishMoveScript.moveFishOnAndroid(-1, 0);
            }
            else if (this.gameObject.name == "ButtonRight")
            {
                fishMoveScript.moveFishOnAndroid(1, 0);
            }
            else
            {
                //Shoud not be happened.
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (this.gameObject.name == "ButtonDown")
        {
            fishMoveScript.moveFishOnAndroid(0, -1);
        }
        else if (this.gameObject.name == "ButtonUp")
        {
            fishMoveScript.moveFishOnAndroid(0, 1);
        }

        buttonPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        buttonPressed = false;
    }
}
