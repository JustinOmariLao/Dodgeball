using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10f;

    // Update is called once per frame
    void Update()
    {
        var controller = GetComponent<CharacterController>();

        Vector3 hor = transform.right * Input.GetAxis("Horizontal");
        Vector3 vert = transform.forward * Input.GetAxis("Vertical");

        Vector3 movement = hor + vert;
        controller.Move(movement * speed * Time.deltaTime);
    }
}
