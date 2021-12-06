using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public Animator anim;
    public bool isGrounded;


    enum EAnim
    {
        PlayerIdle,
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
        animState = EAnim.PlayerIdle;


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
        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0 && Input.GetAxis("Jump") == 0)
        {

            anim.Play("Walk 1");
        }

        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0 && Input.GetAxis("Jump") == 0 && transform.position.y > -1 && !(Input.GetMouseButtonDown(0)))
        {
            animState = EAnim.PlayerIdle;
        }
        if (Input.GetAxis("Jump") > 0)
        {

            anim.Play("PlayerJump");

        }

        if (transform.position.y < -2)
        {
            animState = EAnim.died;

        }
        if (Input.GetMouseButtonDown(0))
        {
            anim.Play("PlayerAttack");
        }


    }

    void DoAnimation()
    {
        switch (animState)
        {
            case  EAnim.PlayerIdle:
                anim.Play("PlayerIdle");
                break;

            case EAnim.moving:
                anim.Play("Walk 1");
                break;

            case EAnim.jumping:
                anim.Play("Jump 0");
                break;

            case EAnim.died:
                anim.Play("Dead00");
                break;

            case EAnim.attacking:
                anim.Play("AttackState");

                break;

            default:
                break;
        }
    }



}