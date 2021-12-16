using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovementController : MonoBehaviour
{

    public CharacterController controller;
    public Transform cam;

    [Header("Hud")]
    public HUD Hud;


    [Header("Inventory")]
    public Inventory inventory;


    [Header("Speed")]
    public float speed = 5f;
    public float turnSmoothTime = .1f;
    float turnSmoothVelocity;

    [Header("Gravity")]
    //public float jumpHeight = 10f;
    public float gravity = -15f;

    public float velocityY;


    [Header("Animation")]
    public Animator animator;


    [Header("Chest interaction")]
    public GameObject ChestInteractionUI;
    private bool triggering;
    public bool IsPickedUp;
    private InventoryItems item;

    //[Header("Health")]
    //public int currentPlayerHealth;

    //private Vector3 velocity;


    void Awake()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();

        
        //Cursor.visible = false;
    }

    void Update()
    {
        Cursor.lockState = CursorLockMode.Confined;
        OpenChest();
        calculateMovement();
    }
    void LateUpdate()
    {
        
       


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
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward + Vector3.up * velocityY;
            controller.Move(moveDirection.normalized * speed * Time.deltaTime);

            //animation
            animator.Play("Walk 1");
        }
        else if ((direction.magnitude == 0f) && Input.GetAxis("Jump") == 0 && !(Input.GetMouseButtonDown(0)))
        {
            animator.Play("PlayerIdle");
        }


        //gravity
        velocityY += Time.deltaTime * gravity;

        if (controller.isGrounded)
        {
            velocityY = 0;
        }

    }

    //check if player controller hits items

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "IsItem" || other.tag == "IsRightItem")
        {

            ChestInteractionUI.SetActive(true);

                triggering = true;
                //get the item component
                item = other.GetComponent<InventoryItems>();
            //if the item excists


          
        }

    }

    void OpenChest()
    {

        if (triggering)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {

                if (item != null)
                {

                    ChestInteractionUI.SetActive(false);
                    //add item to the list
                    inventory.AddItem(item);
                    triggering = false;
                    if (item.Image.name == "icon_itemicon_crown")
                    {
                        IsPickedUp = true;
                        
                    }
                }

            }

        }

    }

    public bool getBool() { return IsPickedUp; }



    void OnTriggerExit(Collider other)
    {
        ChestInteractionUI.SetActive(false);
        triggering = false;
    }

}