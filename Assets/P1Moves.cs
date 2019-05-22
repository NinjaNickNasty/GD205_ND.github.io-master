using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Moves : MonoBehaviour
{
    Vector3 playerPos;
    Vector3 startPos;
    public Transform destination;
    
   


    GameObject[] Hazard;

    GameObject[] Obstacle;

    public TextMesh playerMessage;

    AudioSource aud;
    public AudioClip moveClip;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = transform.position;

        startPos = playerPos;

        Hazard = GameObject.FindGameObjectsWithTag("Hazard");
        Obstacle = GameObject.FindGameObjectsWithTag("Obstacle");
        aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = playerPos;

        playerMessage.text = "welcome to the game";

        if (Input.GetKeyDown(KeyCode.W))
        {
            playerPos += transform.forward;  //moves player 
            transform.position = playerPos;
            aud.PlayOneShot(moveClip);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            playerPos -= transform.forward;
            transform.position = playerPos;
            aud.PlayOneShot(moveClip);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            playerPos -= transform.right;
            transform.position = playerPos;
            aud.PlayOneShot(moveClip);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            playerPos += transform.right;
            transform.position = playerPos;
            aud.PlayOneShot(moveClip);
        }
        for (int i = 0; i < Hazard.Length; i++)
        {
            if (playerPos.x == Hazard[i].transform.position.x &&
                    playerPos.z == Hazard[i].transform.position.z)
            {
                playerPos -= transform.up;

                transform.position = playerPos;

            }
        }

        bool inASpace = false;


        for (int i = 0; i < Obstacle.Length; i++)
        {

            if (newPos.x == Obstacle[i].transform.position.x &&
                newPos.z == Obstacle[i].transform.position.z)
            {
                //if the above is true, you are in a block
                //make inABlock true, so we know you are in a block
                inASpace = true;
            }
        }
        if (!inASpace)
        {
            playerPos = newPos;
        }

    }
}

