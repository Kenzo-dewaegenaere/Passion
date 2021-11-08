using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
        
    public Rigidbody rig;

    [Header("Speed")]
    public float moveSpeed;

    [Header("Jumping")]
    public float jumpForce;
    private bool isGrounded = true;


    // Start is called before the first frame update
    void Start()
    {

        rig = GetComponent<Rigidbody>();
   

    }

    void Update()
    {
        calculateMovement();
    }

    void calculateMovement()
    {

        //get inputs
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");

        //get pos
        Vector3 newPosition = new Vector3(moveHorizontal, 0.0f, moveVertical);

        //direction
        if (moveVertical != 0 || moveHorizontal != 0)
        {

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(newPosition), 0.025F);
        transform.Translate(newPosition * moveSpeed * Time.deltaTime, Space.World);

        }

        //Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

    }



        private void OnCollisionEnter(Collision collision)
    {

        //if on top of object
        if (collision.gameObject.tag == "Env")
        {
            //set grounded to true so the objects know the feet are on top of something
            isGrounded = true;
        }

    }


}   