using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{

    private Rigidbody rb;
    public float playerThrowSpeedInput; //need to calculate by how long they hold mouse button
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        throwBall();
    }

    private void throwBall()
    {
        rb.AddForce(Vector3.forward * playerThrowSpeedInput, ForceMode.Impulse);
        rb.AddForce(Vector3.up * playerThrowSpeedInput / 10, ForceMode.Impulse);
    }
}
