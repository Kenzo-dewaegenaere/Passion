using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcAiController : MonoBehaviour
{

    //public values for my npc and animation 
    public NavMeshAgent agent;
    public Animator anim;

    //radius to walk in, and to set postion
    bool WalkPointPosition;
    public float radius;

    //Layermask to declare where you can walk
    public Vector3 PointToWalk;
    public LayerMask isGround;

    

    private void Awake()
    {
        
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

    }


    private void Update()
    {
         Wandering();
    }

    private void Wandering()
    {

        //if there is no point to walk to, set a walk point
        if (!WalkPointPosition)
        {
            SearchWalkPoint();
        }


        //if there is a walk point, automatic go to the walk point
        if (WalkPointPosition)
        {
         agent.SetDestination(PointToWalk);
        }
        

        Vector3 distanceToWalkPoint = transform.position - PointToWalk;

        //play walk animation
        anim.Play("Walk00");


        //if destination is reached set walk point to false and calculate new one
        if (distanceToWalkPoint.magnitude < 1f)
            WalkPointPosition = false;
    }
    private void SearchWalkPoint()
    {
        //Random position for Z and X inside the givven radius
        float posZ = Random.Range(-radius, radius);
        float posX = Random.Range(-radius, radius);

        //declare the walk point
        PointToWalk = new Vector3(transform.position.x + posX, transform.position.y, transform.position.z + posZ);


        //if the given walk point is on the walkable ground, set it to true
        if (Physics.Raycast(PointToWalk, -transform.up, 2f, isGround))
        {
            WalkPointPosition = true;
        }
          
    }

 
}
