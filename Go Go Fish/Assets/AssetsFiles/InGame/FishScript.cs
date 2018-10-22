using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//FishScript.cs
//The Last Modified Date: 12/10/2018
//Brief description: The script related to the fish (player) in the game.
public class FishScript : MonoBehaviour
{
    public AudioClip soundSeaWeed;
    public AudioClip soundTrash;
    public AudioClip soundBomb;

    private AudioSource sSeaWeed { get { return GetComponent<AudioSource>(); } }
    private AudioSource sTrash { get { return GetComponent<AudioSource>(); } }
    private AudioSource sBomb { get { return GetComponent<AudioSource>(); } }

    int speed = 10;
    int lives = 5;
    int energy = 0;
    float jumpSpeed = 80.0f;
    Rigidbody2D rb;

    //Method name: void Start()
    //Brief description: Use this for initialization.
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameObject.AddComponent<AudioSource>();

        sSeaWeed.clip = soundSeaWeed;
        sSeaWeed.playOnAwake = false;

        sTrash.clip = soundTrash;
        sTrash.playOnAwake = false;

        sBomb.clip = soundBomb;
        sBomb.playOnAwake = false;
    }

    void PlaySound(string str)
    {
        if (str.Equals("Seaweed"))
        {
            sSeaWeed.PlayOneShot(soundSeaWeed);
        }
        else if (str.Equals("Trash"))
        {
            sTrash.PlayOneShot(soundTrash);
        }
        else if (str.Equals("Bomb"))
        {
            sBomb.PlayOneShot(soundBomb);
        }
    }

    //Method name: void Update()
    //Brief description: Update is called once per frame.
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

    //Method name: void OnTriggerEnter2D(Collider2D other)
    //Brief description: Check the collision to interect with the game system.
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Trash"))
        {
            PlaySound("Trash");
            this.lives--;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag.Equals("Seaweed"))
        {
            PlaySound("Seaweed");
            this.energy++;
            Destroy(other.gameObject);
            transform.localScale += new Vector3(0.05f, 0.05f, 0);

            if (energy > 9)
            {
                lives++;
                energy = 0;
            }
        }
        else if (other.gameObject.tag.Equals("Bomb"))
        {
            PlaySound("Bomb");
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

    //Method name: void gameOver()
    //Brief description: Trigger game over status.
    //Related source (next step): ScoreScript.cs -> void Update()
    void gameOver()
    {
        Destroy(this.gameObject);
    }

    //Method name: void moveFish()
    //Brief description: Move fish to swim.
    void moveFish()
    {
        float keyHorizontal = Input.GetAxis("Horizontal");
        //float keyVertical = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * speed * Time.smoothDeltaTime * keyHorizontal, Space.World);
        //transform.Translate(Vector3.up * speed * Time.smoothDeltaTime * keyVertical, Space.World);
    }

    //Method name: void energyChecker()
    //Brief description: Check energy and when it reaches 10, its 0 but the lives will increase.
    public void energyChecker()
    {
        if(energy > 9)
        {
            this.lives++;
            energy = 0;
        }
    }

    //Method name: int getLives()
    //Brief description: return lives.
    public int getLives()
    {
        return lives;
    }

    //Method name: int getEnergy()
    //Brief description: return energy.
    public int getEnergy()
    {
        return energy;
    }

    //Method name: void OnBecameInvisible()
    //Brief description: when the fish goes outside of the camera, the game will end.
    void OnBecameInvisible()
    {
        gameOver();
    }
}
