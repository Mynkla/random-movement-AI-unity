//  Random movement script for Unity GameObjects
//  Written by Johnny Dunn
//  GameObjects with this script attached will constantly move at a random range of speed
//  and rotate at a random range of angles, and upon collision with walls or other GameObject tags,
//  the movement direction will change.

using UnityEngine;
using System.Collections;

public class RandomMovement : MonoBehaviour {

    //public AudioClip AlienScream;
    
    public float speed;
    public int rotationSpeed;
    public int maxdistance;
    float timeVar = 0;
    float step = Mathf.PI / 60;
    float rotationRange = 120;                  //  How far should the object rotate to find a new direction?
    float baseDirection = 0;

    Vector3 randomDirection;                // Random direction to begin in

    // Use this for initialization
    void Start()
    {
        randomDirection = new Vector3(0, 1, 0);         //  Initializes a direction to go in 
                                                        //  Initial direction doesn't matter because this script
                                                        //  will make things move at random angles constantly.
    }

    void OnCollisionEnter (Collision col) 
    {
        if (col.gameObject.tag == "WallTag"){                   //  Tag it with a wall or other object
    //          audio.PlayOneShot (AlienScream, 2.0f);         //  Plays a sound on collision
            baseDirection = baseDirection + Random.Range (-30, 30);   // Switch direction on collision
        }
    }

   /* void OnCollisionEnter(Collision collision)              //  Another collision
    {
        baseDirection = baseDirection + Random.Range(-15.0f, 15.0f);

        if (collision.gameObject.name == "Refined Controller")        //  Collides with player
        {
            Application.LoadLevel("Title");               //  Reload the level if the player is hit
        }
    } */

    void Update()
    {
        randomDirection = new Vector3(0, Mathf.Sin(timeVar) * (rotationRange / 2) + baseDirection, 0); //   Moving at random angles 
        timeVar += step;
        speed = Random.Range(2.0f, 20.0f);              //      Change this range of numbers to change speed
        GetComponent<Rigidbody>().AddForce(transform.forward * speed);
        transform.Rotate(randomDirection * Time.deltaTime * 10.0f);         //  This line is so the GameObject doesn't just go straight.
    }

