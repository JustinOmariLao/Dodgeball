using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    public Animator playerAnims;
    
    public bool moving = false;
    private Vector3 lastPos;

    private Rigidbody rb;
    private Vector3 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lastPos = transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        // movement = Vector3.zero;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        movement = transform.forward * vertical + transform.right * horizontal;

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);


//see if moving
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            moving = true;

            //check which direction they are moving on x axis
            if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                playerAnims.SetBool("Left", false);
                playerAnims.SetBool("Right", false);         
            }            
            else if (!Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
            {
                playerAnims.SetBool("Right", true);
                playerAnims.SetBool("Left", false);
            } 
            else if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                playerAnims.SetBool("Left", true);
                playerAnims.SetBool("Right", false);
            }

            //check which direction they are moving on z axis
            if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
            {
                playerAnims.SetBool("Backwards", false);
                playerAnims.SetBool("Forwards", false);
            }
            else if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
            {
                playerAnims.SetBool("Forwards", true);
                playerAnims.SetBool("Backwards", false);
            } 
            else if (!Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))
            {
                playerAnims.SetBool("Backwards", true);
                playerAnims.SetBool("Forwards", false);
            }

            // //check which direction they are moving on x axis
            // if (Mathf.Approximately(transform.position.x, lastPos.x))
            // {
            //     playerAnims.SetBool("Left", false);
            //     playerAnims.SetBool("Right", false);                
            // }            
            // else if (transform.position.x > lastPos.x)
            // {
            //     playerAnims.SetBool("Right", true);
            //     playerAnims.SetBool("Left", false);
            // } 
            // else if (transform.position.x < lastPos.x)
            // {
            //     playerAnims.SetBool("Left", true);
            //     playerAnims.SetBool("Right", false);
            // }

            // //check which direction they are moving on z axis
            // if (Mathf.Approximately(transform.position.z, lastPos.z))
            // {
            //     playerAnims.SetBool("Backwards", false);
            //     playerAnims.SetBool("Forwards", false);
            // }
            // else if (transform.position.z > lastPos.z)
            // {
            //     playerAnims.SetBool("Forwards", true);
            //     playerAnims.SetBool("Backwards", false);
            // } 
            // else if (transform.position.z < lastPos.z)
            // {
            //     playerAnims.SetBool("Backwards", true);
            //     playerAnims.SetBool("Forwards", false);
            // }
        }
        else
        {
            moving = false;
        }
        playerAnims.SetBool("Moving", moving);
        lastPos = transform.position;                
    }
}
