using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
        
 public Rigidbody rig;

    [Header("Speed")]
    public float moveSpeed;

    private bool isGrounded = true;

   



    [Header("Jumping")]
    public float jumpForce;



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
        //Get inputs
        float x = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float z = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        //direction
        Vector3 directrion = new Vector3(x, z, 0f);

        //Move
        transform.Translate(x, 0, z);

        //Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {

            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        //Rotation
        if (x != 0 || z != 0)
        {       
        
        // rig.transform.rotation = Quaternion.Slerp(rig.transform.rotation, Quaternion.LookRotation(new Vector3(x, 0, z), Vector3.up), Time.deltaTime * 40f);
            //rig.transform.rotation = rot;

        }


    }



        private void OnCollisionEnter(Collision collision)
    {

        //if ontop of object
        if (collision.gameObject.tag == "Env")
        {
            isGrounded = true;
        }

    }


}   