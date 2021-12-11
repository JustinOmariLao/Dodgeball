using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Ragdoll : MonoBehaviour
{
    public Animator anim;
    public NavMeshAgent agent;

    void OnCollisionEnter(Collision collisionInfo)
    {
        Debug.Log("Collision Triggered");
        
        if (collisionInfo.gameObject.name == "Dodgeball")
        {
            
            if(collisionInfo.gameObject.GetComponent<Pickup>().thrown == true)
            {
                anim.enabled = false;
                agent.enabled = false;
                GetComponentInParent<Enemy>().enabled = false;
            }
        }
            
    }
    
}
