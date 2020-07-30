using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{
    public float speed = 3f;
    public GameObject player;
    private Rigidbody2D rb2D;
  


    public void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector3 pos = transform.position;
        if (Input.GetKey("w"))
        {
            pos.y += speed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            pos.y -= speed * Time.deltaTime;
            
        }
        if (Input.GetKey("d"))
        {
            pos.x += speed * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            pos.x -= speed * Time.deltaTime;
        }



        if (Input.GetKeyDown("s"))
        {
            player.GetComponent<Animator>().Play("playerwalksouth");
        }
        if (Input.GetKeyDown("w"))
        {
            player.GetComponent<Animator>().Play("walkingnorth");
        }
        if (Input.GetKeyDown("a"))
        {
            player.GetComponent<Animator>().Play("walkingwest");
        }
        if (Input.GetKeyDown("d"))
        {
            player.GetComponent<Animator>().Play("walkingeast");
        }



        if (Input.GetKeyUp("s"))
        {
            player.GetComponent<Animator>().Play("idlesouth");
        }


        if (Input.GetKeyUp("w"))
        {
            player.GetComponent<Animator>().Play("idlenorth");
        }


        if (Input.GetKeyUp("a"))
        {
            player.GetComponent<Animator>().Play("idlewest");
        }
        else if (Input.GetMouseButtonDown(0))
        {
            player.GetComponent<Animator>().Play("swordwest");

        }

        if (Input.GetKeyUp("d"))
        {
            player.GetComponent<Animator>().Play("idleeast");
        }
        else if (Input.GetMouseButtonDown(0))
        {
            player.GetComponent<Animator>().Play("swordeast");

        }


    }



    public void FixedUpdate()
    {
        GetInput();
        MoveCharacter(movement);
    }

    private void GetInput()
    {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }
    public void MoveCharacter(Vector2 movementVector)
    {
        movementVector.Normalize();
        // move the RigidBody2D instead of moving the Transform
        rb2D.velocity = movementVector * speed;
    }
    public Vector2 movement = new Vector2();
}
