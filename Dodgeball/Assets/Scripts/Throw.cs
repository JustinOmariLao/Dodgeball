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
        throwBall();
    }

    // // FixedUpdate is called once per frame
    // void FixedUpdate()
    // {
    //     Speed = rb.velocity.magnitude;
    //     AngularSpeed = rb.angularVelocity.magnitude;

    //     if (thrown && rb.velocity.magnitude < 25) {
    //         rb.AddForce(Vector3.forward * throwForce(), ForceMode.Impulse);
    //         rb.AddForce(Vector3.up * throwForce() / 10, ForceMode.Impulse);
    //     }
    // }

    // float throwForce() 
    // {
    //     return (playerThrowSpeedInput > 0) ? playerThrowSpeedInput -= ballAirDrag : 0.0f;
    // }

    // void OnCollisionEnter(Collision collisionInfo) {
    //     thrown = false;
    //     Debug.Log("Triggered Collision");
    // }

    private void throwBall()
    {
        rb.AddForce(Vector3.forward * playerThrowSpeedInput, ForceMode.Impulse);
        rb.AddForce(Vector3.up * playerThrowSpeedInput / 10, ForceMode.Impulse);
    }
}
