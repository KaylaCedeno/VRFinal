using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // defined local variables
    public CharacterController controller;

    public float speed = 5;
    public float gravity = -9.18f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

   
    void Update()
    {

        // checks if the player is standing on the ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // keeps player grounded if their velocity is < 0 (aka they are falling) + redirects to -2f
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // if the player uses the left shift key to move, then speed is set to 10
        if (Input.GetKey("left shift") && isGrounded)
        {
            speed = 10;
        }

        // otherwise speed is set to 5
        else
        {
            speed = 5;
        }

        // variables
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        // if the jump button is pressed and the player is grounded..
       // if (Input.GetButtonDown("Jump") && isGrounded)
       if ( OVRInput.Get(OVRInput.Button.One) && isGrounded)
        {
            // set velocity based on the jump height and gravity
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
