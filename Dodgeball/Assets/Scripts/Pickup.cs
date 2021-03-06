using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Rigidbody rb;
    public SphereCollider coll;
    public Transform player, dodgeballContainer, cam;

    public float pickupRange;
    public float playerThrowSpeedInput = 40f; //NEED TO CHANGE TO INTAKE LENGTH OF PLAYER INPUT ON MOUSE1

    public bool thrown;
    public bool equipped;
    public static bool slotFull;

    private Vector3 startingTransform;

    void Awake() 
    {
        thrown = false;
        Physics.IgnoreLayerCollision(6,7);
        Physics.IgnoreLayerCollision(6,10);
        startingTransform = transform.position;
        slotFull = false;
    }

    void Update()
    {
        //check distance to player
        Vector3 distanceToPlayer = player.position - transform.position;
        if (equipped && Input.GetKeyDown(KeyCode.E)) DropBall(); 
        if (!equipped && distanceToPlayer.magnitude <= pickupRange && Input.GetKeyDown(KeyCode.E) && !slotFull) PickupBall();
        if (equipped && Input.GetMouseButtonDown(0)) ThrowBall();
        
    }

    private void PickupBall()
    {
        equipped = true;
        slotFull = true;

        //move ball into player's hand
        transform.SetParent(dodgeballContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);


        //make rigidbody non interactible and shut off physics
        rb.isKinematic = true;
        coll.isTrigger = true;
    }

    private void DropBall()
    {
        equipped = false;
        slotFull = false;

        transform.SetParent(null);
        transform.rotation = player.rotation;

        //make rigidbody interactible and turn on physics
        rb.isKinematic = false;
        coll.isTrigger = false;
    }

    private void ThrowBall()
    {
        thrown = true;
        equipped = false;
        slotFull = false;

        transform.SetParent(null);
        transform.rotation = player.rotation;

        //make rigidbody interactible and turn on physics
        rb.isKinematic = false;
        coll.isTrigger = false;

        rb.AddForce(player.forward * playerThrowSpeedInput, ForceMode.Impulse);
        rb.AddForce(Vector3.up * playerThrowSpeedInput / 10, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        // if (collisionInfo.gameObject.name == "Player") 
        //     rb.AddForce(player.GetComponent<Rigidbody>().velocity);
        if (collisionInfo.gameObject.name == "Barrier")
            resetBallLocation();
        if (collisionInfo.gameObject.name == "Ground")
            thrown = false;
    }

    void resetBallLocation() 
    {
        thrown = false;
        transform.position = startingTransform;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
    }
}
