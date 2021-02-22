using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int doublJumpCounter = 1;
    public CharacterController characterController;
    public float speed = 10f;
    public float jumpForce;
    public float gravity = -9.81f;

    private Vector3 moveDirection;
    public float gravityScale;

    public Transform pivot;
    public float rotateSpeed;

    public GameObject playerModel;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        MoveWithGravity();

    }

    void MoveWithGravity()
    {

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        //moveDirection = new Vector3(x * speed, moveDirection.y, z * speed);

        //store y before normalized the moveDirection
        float yStore = moveDirection.y;

        moveDirection = (transform.forward * z) + (transform.right * x);
        moveDirection = moveDirection.normalized * speed;
        moveDirection.y = yStore;

        if (characterController.isGrounded) 
        {

            moveDirection.y = 0f;
            doublJumpCounter = 1;
            if(Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
            }

        }

        if (!characterController.isGrounded && doublJumpCounter > 0)
        {
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
                doublJumpCounter = 0;
            }
            
        }
        
        moveDirection.y = moveDirection.y + (gravity * gravityScale);
        characterController.Move(moveDirection * Time.deltaTime);
        
        //move player based on camera look direction
        if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            transform.rotation = Quaternion.Euler(0f, pivot.rotation.eulerAngles.y, 0f);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
            playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
        }




    }

    
   
   
}
