using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
  
    public CharacterController controller;
    public Transform cam;

    [Header("Speed")]
    public float speed =5f;
    public float turnSmoothTime = .1f;
    float turnSmoothVelocity;

    [Header("Jumping")]
    public float jumpHeight = 6f;
    public float gravity = -12f;
    public float velocityY;
    private bool isGrounded = true;


    void start()
    {
        controller = GetComponent<CharacterController>();
    }



    void Update()
    {
        calculateMovement();
    }

    void calculateMovement()
    {


        //get inputs
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        //get direction and normalize it
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        

        if (direction.magnitude >= .1f)
        {
            //get the angle player is looking at
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            //rate to angle
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            //move to angle
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward +Vector3.up * velocityY;
            controller.Move(moveDirection.normalized * speed * Time.deltaTime);
        }

        //jump

        velocityY += Time.deltaTime * gravity;

        if (controller.isGrounded)
        {
            velocityY = 0;
        }

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
           // Debug.Log("in air");

        }

    }

    void Jump() {

        if (controller.isGrounded)
        {
            velocityY = 0;
        }
    }

}   