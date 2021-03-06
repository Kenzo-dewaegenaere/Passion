using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
  
    public CharacterController controller;
    public Transform cam;

    [Header("Hud")]
    public HUD Hud;


    [Header("Inventory")]
    public Inventory inventory;


    [Header("Speed")]
    public float speed =5f;
    public float turnSmoothTime = .1f;
    float turnSmoothVelocity;

    [Header("Jumping")]
    public float jumpHeight = 10f;
    public float gravity = -15f;
   
    public float velocityY;


    [Header("Health")]
    public int currentPlayerHealth;

  //private Vector3 velocity;

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


        //gravity

        velocityY += Time.deltaTime * gravity;

        if (controller.isGrounded)
        {
           velocityY = 0;
        }

    }

    //check if player controller hits items
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //get the item component
        InventoryItems item = hit.collider.GetComponent<InventoryItems>();

        //if the item excists
        if (item != null)
        {
            

            //add item to the list
            inventory.AddItem(item);
        }



    }
}   