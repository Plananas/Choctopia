using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float speed = 10, jumpVelocity = 10;
    public LayerMask playerMask;
    Transform myTrans, tagGround, tagRoof;
    Rigidbody2D myBody;

    public bool isGrounded = false;
    public bool touchingRoof = false;

    //lets me access the animator so that i can set conditions
    public Animator animator;



    void Start()
    {
        myBody = this.GetComponent<Rigidbody2D>();
        myTrans = this.transform;
        
        //Finds the groundChecker that is parented to the Player
        tagGround = GameObject.Find(this.name+"/tag_ground").transform;
        tagRoof = GameObject.Find(this.name+"/tag_roof").transform;

    }

    void FixedUpdate()
    {
        touchingRoof = Physics2D.Linecast(myTrans.position, tagRoof.position, playerMask);
        isGrounded = Physics2D.Linecast(myTrans.position, tagGround.position, playerMask);

        //calls the "move" function
        Move(Input.GetAxisRaw("Horizontal"));

        //if you press space it calls the "Jump" function
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
            
        }

        //If you press S, call the crouch function
        
        Crouching(Input.GetAxisRaw("Vertical"));
        


        //If the player is off the ground then the jump, parameters for the animation becomes true
        if (isGrounded == false)
        {
            animator.SetBool("Jumping", true);
        }


    }
    public void Move(float horizontalInput)
    {
        //Applies the input to the character by adding a velocity to it
        Vector2 moveVel = myBody.velocity;
        moveVel.x = horizontalInput * speed;
        myBody.velocity = moveVel;
        Debug.Log($"horizontal input:{horizontalInput}");
        Debug.Log($"moveVel: {moveVel}");



        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));
        
        

    }
    void Update()
    {
        //whenever the player is grounded, the parameter for jumping is false
        if(isGrounded == true)
        {
            animator.SetBool("Jumping", false);
        }
    }
    public void Jump()
    {
        //If the player is on the ground and not under something then a force is put on it to "jump"
        if (isGrounded && !touchingRoof)
        {
            myBody.velocity += jumpVelocity * Vector2.up;

            //Plays the animation for jumping
            animator.SetTrigger("Takeoff");
        }
        
      

    }

    public Collider2D UprightCollider;
    public Collider2D CrouchCollider;

    //When the player presses S, rescale the collider so that it fits under the gap
    public void Crouching(float verticalInput)
    {
        //isGrounded = Physics2D.Linecast(myTrans.position, tagGround.position, playerMask);
        //you crouch if you are already under something or you are pressing "S"
        if ((isGrounded == true && verticalInput < 0) || touchingRoof)
        {
            //if it meets the conditions, disable normal collider and activate crouch collider
            UprightCollider.enabled = false;
            CrouchCollider.enabled = true;
            animator.SetBool("Crawling", true);
            speed = 3f;

        }

        else
        {
            // when the player is stationary or in the air, they shouldent be crouching
            CrouchCollider.enabled = false;
            UprightCollider.enabled = true;
            animator.SetBool("Crawling", false);
            speed = 10f;

        }
    }
}
