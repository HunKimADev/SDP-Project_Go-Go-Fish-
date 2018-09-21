using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FishScript : MonoBehaviour
{
    int speed = 10;
    int lives = 5;
    int energy = 0;
    float jumpSpeed = 80.0f;
    Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveFish();

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.AddForce(jumpSpeed * transform.up);

            //rb.AddForce(new Vector2(0, 1, 0) * jumpSpeed, ForceMode.Impulse);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            rb.AddForce(jumpSpeed * -1 * transform.up);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Trash"))
        {
            this.lives--;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag.Equals("Seaweed"))
        {
            this.energy++;
            Destroy(other.gameObject);

            if (energy > 9)
            {
                lives++;
                energy = 0;
            }
        }
        else if (other.gameObject.tag.Equals("Bomb"))
        {
            this.lives-= 2;
            this.energy = 0;
            Destroy(other.gameObject);
        }

        if (lives < 1)
        {
            lives = 0;
            gameOver();
        }
    }

    void gameOver()
    {
        Destroy(this.gameObject);
    }

    void moveFish()
    {
        float keyHorizontal = Input.GetAxis("Horizontal");
        //float keyVertical = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * speed * Time.smoothDeltaTime * keyHorizontal, Space.World);
        //transform.Translate(Vector3.up * speed * Time.smoothDeltaTime * keyVertical, Space.World);
    }

    public void energyChecker()
    {
        if(energy > 9)
        {
            this.lives++;
            energy = 0;
        }
    }

    public void moveFishOnAndroid(float hInput, float vInput)
    {
        float keyHorizontal = hInput;
        //float keyVertical = vInput;

        transform.Translate(Vector3.right * speed * Time.smoothDeltaTime * keyHorizontal, Space.World);

        if(vInput == 1)
        {
            rb.AddForce(jumpSpeed * transform.up);
        }
        else if(vInput == -1)
        {
            rb.AddForce(jumpSpeed * -1 * transform.up);
        }

        //transform.Translate(Vector3.up * speed * Time.smoothDeltaTime * keyVertical, Space.World);
    }

    public int getLives()
    {
        return lives;
    }

    public int getEnergy()
    {
        return energy;
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
        //SceneManager.LoadScene("TitleMenuScene");
    }
}
