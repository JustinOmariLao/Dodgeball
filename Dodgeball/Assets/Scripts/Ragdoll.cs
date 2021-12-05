using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    public Animator anim;
    
    void OnCollisionEnter(Collision collisionInfo)
    {
        Debug.Log("Collision Triggered");
        if (collisionInfo.gameObject.name == "Dodgeball")
            anim.enabled = false;

    }
    
}
