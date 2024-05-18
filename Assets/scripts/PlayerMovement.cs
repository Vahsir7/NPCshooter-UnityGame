using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector2 movementInput;
    [SerializeField] CharacterController controller;
    public float speed = 10f;

    [SerializeField] float gravity = -9.81f;
    Vector3 verticalVelocity = Vector3.zero;

    [SerializeField] LayerMask groundMask;
    bool isGrounded;

    [SerializeField] float jumpHeight = 3f;
    bool jump;

    private void Update()
    {
        Vector3 horizontalVelocity = (transform.right * movementInput.x + transform.forward * movementInput.y) * speed;
        controller.Move(horizontalVelocity * Time.deltaTime);

        isGrounded = Physics.CheckSphere(transform.position, 0.1f, groundMask);
        if (isGrounded)
        {
            //print("grounded");
            verticalVelocity.y = 0f;
        }

        if(jump)
        {
            //print("jump!!!");
            if(isGrounded)
            {
                //print("jumping");
                verticalVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); 
            }
            else
            {
                //print("not jumping");
            }
            jump = false;
        }

        verticalVelocity.y += gravity * Time.deltaTime;
        controller.Move(verticalVelocity * Time.deltaTime);
    }
    public void ReceiveInput(Vector2 _movementInput)
    {
        movementInput = _movementInput;
        //print(movementInput);
    }

    public void onJumpPressed()
    {
        jump = true;
    }
}