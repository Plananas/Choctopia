using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpOnHead : MonoBehaviour
{
    public GameObject rabbit;
    public Rigidbody2D Player1, Player2;

    public float Force;


    //private readonly string selectedCharacter = "SelectedCharacter";

    
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D trig)
    {
        //if the head collider collides with the footcollider
        if (trig.gameObject.CompareTag("FootCollider"))
        {
            Debug.Log("Hit");
            Player2.velocity = Force * new Vector2(0, Force);
            Player1.velocity = Force * new Vector2(0, Force);
            
            //destroys the rabbit if jumped on
            Destroy(rabbit.gameObject);
        }
    }
}
