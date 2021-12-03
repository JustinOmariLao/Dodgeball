using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    public float Speed;
    public float AngularSpeed;
    public float ballAirDrag;
    Rigidbody rb;

    public float playerThrowSpeedInput; //need to calculate by how long they hold mouse button
    private bool thrown;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        thrown = true;
    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        Speed = rb.velocity.magnitude;
        AngularSpeed = rb.angularVelocity.magnitude;

        if (thrown && rb.velocity.magnitude < 25) {
            rb.AddForce(Vector3.forward * throwForce());
            rb.AddForce(Vector3.up * throwForce() / 10);
        }
    }

    float throwForce() 
    {
        return (playerThrowSpeedInput > 0) ? playerThrowSpeedInput -= ballAirDrag : 0.0f;
    }

    void OnCollisionEnter(Collision collisionInfo) {
        thrown = false;
        Debug.Log("Triggered Collision");
    }
}
