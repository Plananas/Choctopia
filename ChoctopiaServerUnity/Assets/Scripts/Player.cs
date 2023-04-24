using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int id;
    public string username;

    public LayerMask playerMask;
    public Rigidbody2D myBody;
    Transform myTrans, tagGround;


    public float moveSpeed = 5f;
    public float jumpVelocity = 5f;
    public bool isGrounded = false;
    public GameObject groundTagObject;

    public int itemAmount = 0;
    public int maxItemAmount = 3;
    public float maxHealth = 100f;
    public float health;


    private bool[] inputs;


    private void Start()
    {
        myBody = this.GetComponent<Rigidbody2D>();

        myTrans = this.transform;
        tagGround = groundTagObject.transform;
    }

    public void Initialize(int _id, string _username)
    {
        id = _id;
        username = _username;

        health = maxHealth;

        inputs = new bool[5];
    }

    /// <summary>Processes player input and moves the player.</summary>
    public void FixedUpdate()
    {
        isGrounded = Physics2D.Linecast(myTrans.position, tagGround.position, playerMask);
        //Debug.Log(isGrounded);

        float _inputDirection = 0;
        //Vector2 _inputDirection = Vector2.zero;
        if (inputs[2])
        {
            _inputDirection -= 1;
            //Debug.Log($"input is {_inputDirection}");
        }
        if (inputs[3])
        {
            _inputDirection += 1;
            //Debug.Log($"input is {_inputDirection}");
        }
        if (inputs[4])
        {
            if (isGrounded)
            {
                //Made checks to see if the jump key was being pressed...
                //Made checks to see if the player was touching ground...
                isGrounded = false;
                //Debug.Log("Jump");
                myBody.AddForce(new Vector2(0f, jumpVelocity), ForceMode2D.Impulse);
            }
        }

        Move(_inputDirection);
    }

    private void Move(float _inputDirection)
    {
        //Debug.Log($"Move Direction is{_inputDirection}");

        Vector3 movement = new Vector3(_inputDirection, 0f, 0f);
        transform.position += movement * moveSpeed;

        ///This code makes the player fall very slowly so i wont be using this...
        //Vector2 moveVel = _inputDirection * moveSpeed;
        //myBody.velocity = moveVel;


        ServerSend.PlayerPosition(this);

    }


    public void Shoot(Vector3 _viewDirection)
    {
        //if (Physics.Raycast(shootOrigin.position, _viewDirection, out RaycastHit _hit, 25f))
        //{
        //    if (_hit.collider.CompareTag("Player"))
        //    {
        //        _hit.collider.GetComponent<Player>().TakeDamage(50f);
        //    }
        //}
    }

    public void TakeDamage(float _damage)
    {
        //if (health <= 0f)
        //{
        //    return;
        //}

        //health -= _damage;
        //if (health <= 0f)
        //{
        //    health = 0f;
        //   controller.enabled = false;
        //    transform.position = new Vector3(0f, 25f, 0f);
        //    ServerSend.PlayerPosition(this);
        //    StartCoroutine(Respawn());
        //}

        ServerSend.PlayerHealth(this);
    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(5f);

        health = maxHealth;
        //controller.enabled = true;
        ServerSend.PlayerRespawned(this);
    }

    public bool AttemptPickupItem()
    {
        

        itemAmount++;
        return true;
    }

    public void SetInput(bool[] _inputs, Quaternion _rotation)
    {
        inputs = _inputs;
        transform.rotation = _rotation;
    }

    /// <summary>Updates the player input with newly received input.</summary>
    /// <param name="_inputs">The new key inputs.</param>
}
