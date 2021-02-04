using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController chomp;
    Vector3 velocity;
    public float speed = 12f;
    public float gravity = -9.81f;

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        chomp.Move(move * speed * Time.deltaTime);
        chomp.Move(velocity * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;


    }
}
