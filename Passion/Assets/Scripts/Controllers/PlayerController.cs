using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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

        
        //if (Input.GetButtonDown("Jump") && controller.isGrounded)
        //// (-0.5) change this value according to your character y position + 1
        //{
        //    velocity.y = jumpHeight;
           
        //}
        //else
        //{
        //    velocity.y += gravity * Time.deltaTime;
        //}
        //controller.Move(velocity * Time.deltaTime);



    }

    bool triggerEntered = false;

    IEnumerator OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            triggerEntered = true;

            //Decrease while triggerEntered is true
            while (triggerEntered)
            {


                Debug.Log("hit");

                yield return new WaitForSeconds(1);
              
            }
        }
        else
        {
            triggerEntered = false;
            Debug.Log("No hit");
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