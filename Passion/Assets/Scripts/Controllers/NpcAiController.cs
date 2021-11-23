using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcAiController : MonoBehaviour
{

    //public values for my npc , animation and player direction
    public NavMeshAgent agent;
    public Animator anim;
    public Transform player;
    public LayerMask isGround, isPlayer;



    private void Awake()
    {
        
        anim = GetComponent<Animator>();

    }

    void Start()
    {
       
    }

    private void Update()
    {
        
        
        anim.Play("Idle01");
        transform.LookAt(player);

    }


}
