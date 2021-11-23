using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator anim;
    public bool isGrounded;


    enum EAnim
    {
        idle,
        moving,
        jumping,
        attacking,
        died
    }
    private EAnim prevAnimState;
    private EAnim animState;

    // Start is called before the first frame update
    void Start()
    {

        anim = GetComponent<Animator>();
        animState = EAnim.idle;


    }

    // Update is called once per frame
    void Update()
    {

        prevAnimState = animState;
        UpdateAnimState();

        if (animState != prevAnimState)
        {
            DoAnimation();
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts[0].normal == Vector3.up)
        {
            isGrounded = true;
        }
    }

    void UpdateAnimState()
    {
        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0 && Input.GetAxis("Jump") == 0 && transform.position.y > -1)
        {

            animState = EAnim.moving;
        }

        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0 && Input.GetAxis("Jump") == 0 && transform.position.y > -1 && !(Input.GetMouseButtonDown(0)))
        {

            animState = EAnim.idle;
        }
        if (Input.GetAxis("Jump") > 0)
        {

            animState = EAnim.jumping;

        }

        if (transform.position.y < -2)
        {
            animState = EAnim.died;

        }
        if (Input.GetMouseButtonDown(0))
        {
            anim.Play("AttackState");
        }
            

    }

    void DoAnimation()
    {
        switch (animState)
        {
            case EAnim.idle:
                anim.Play("Idle");
                break;

            case EAnim.moving:
                anim.Play("Walk00");
                break;

            case EAnim.jumping:
                anim.Play("Jump00");
                break;

            case EAnim.died:
                anim.Play("Dead00");
                break;

            case EAnim.attacking:
                anim.Play("Attack00");
                
                break;

            default:
                break;
        }
    }



}