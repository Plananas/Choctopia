using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    public float destroyTimer = 2f;
    //public Animator animator;
    public GameObject collectedItem;
    //public AudioSource CollectNoise;

    void OnTriggerEnter2D(Collider2D other)
    {
        //Plays the collection noise
        //CollectNoise.Play();
        //Plays timerEnded function after a specified amount of time
        Invoke("timerEnded", destroyTimer);
        //Plays the "collected" animation
        //animator.SetBool("Collected", true);
        //Destroys the collider
        collectedItem.GetComponent<Collider2D>().enabled = false;
        //Adds 1 to the score
        Scoring.theScore += 1;
        
    }

    void timerEnded()
    {
        //Destroys the game object
        Destroy(collectedItem.gameObject);
    }
}
