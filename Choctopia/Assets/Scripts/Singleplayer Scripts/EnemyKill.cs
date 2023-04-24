using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKill : MonoBehaviour
{

    public Rigidbody2D Player1, Player2;
    public GameObject Player1Ob, Player2Ob;
    public float Force;
    public float Force2;

    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.CompareTag("Player"))
        {
            Debug.Log("works");
            //Player1.velocity = (new Vector2(Force, Force2));
            //Player2.velocity = (new Vector2(Force, Force2));
            //Destroys the player when they walk into the enemy
            Destroy(Player1Ob.gameObject);
            Destroy(Player2Ob.gameObject);


        }
    }
}
