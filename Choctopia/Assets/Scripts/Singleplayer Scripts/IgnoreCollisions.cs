using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollisions : MonoBehaviour
{

    //public GameObject objectCollider;
 
    void Start()
    {
        //When the two objects collide then they wont collide
        Physics2D.IgnoreLayerCollision(8, 8);
        Physics2D.IgnoreLayerCollision(9, 9);

        Physics2D.IgnoreLayerCollision(8, 9);

        Physics2D.IgnoreLayerCollision(8, 11);
        Physics2D.IgnoreLayerCollision(8, 12);

        Physics2D.IgnoreLayerCollision(9, 11); 
        Physics2D.IgnoreLayerCollision(9, 12);

        Physics2D.IgnoreLayerCollision(11, 13);
    }

 
}
