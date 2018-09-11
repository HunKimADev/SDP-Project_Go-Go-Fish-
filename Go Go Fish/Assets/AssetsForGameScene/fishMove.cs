using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fishMove : MonoBehaviour
{

    int speed = 10;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moveFish();
    }

    void moveFish()
    {
        float keyHorizontal = Input.GetAxis("Horizontal");
        float keyVertical = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * speed * Time.smoothDeltaTime * keyHorizontal, Space.World);
        transform.Translate(Vector3.up * speed * Time.smoothDeltaTime * keyVertical, Space.World);
    }

    void OnBecameInvisible()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
