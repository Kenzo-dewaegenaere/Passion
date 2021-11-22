using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAiController : MonoBehaviour
{

    //public values for my npc , animation and player direction
    public NavMeshAgent agent;
    public Animator anim;
    public Transform player;

    public GameObject playerHealth;
    private PlayerController currentPlayerHealth;


    //radius to walk in, and to set postion
    bool WalkPointPosition;
    public float radius;

    //Layermask to declare where you can walk
    public Vector3 PointToWalk;
    public LayerMask isGround, isPlayer;

    //declare range on enemy player has to be in, to set bool false or true
    public float inAgressiveRange;
    private bool playerInAgressiveRange;

    //declare range on enemy player has to be in, to set bool false or true
    public float inAttackRange;
    private bool playerInFightRange;


    //health set to enemy
    [Header("Health")]
    public int currentEnemyHealth;
    private bool dead = false;


    private void Awake()
    {
        
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;
        anim = GetComponent<Animator>();

    }

    void Start()
    {
        currentPlayerHealth = playerHealth.GetComponent<PlayerController>();
    }


    private void Update()
    {
        //Look if the player is inside the aggresive range and attack, if so set to true
        playerInAgressiveRange = Physics.CheckSphere(transform.position, inAgressiveRange, isPlayer);
        playerInFightRange = Physics.CheckSphere(transform.position, inAttackRange, isPlayer);


        if (currentEnemyHealth <= 0)
        {
            dead = true;
            Debug.Log("im dead");
            anim.Play("Dead00");
            Destroy(gameObject, 2);
        }

        //check if the player is in sight
        if ((playerInAgressiveRange || playerInFightRange) && !dead)
        {
            if (playerInAgressiveRange && !playerInFightRange) 
            {
                Agressive(); 
            }
            else if (playerInFightRange && playerInAgressiveRange)
            {  
                Fight();
            }
        }
        else 
        { 
            Wandering(); 
        }

        if (currentEnemyHealth <= 0)
        {
            dead = true;
            Debug.Log("im dead");
            anim.Play("Dead00");
            Destroy(gameObject, 2);
        }

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
    private void Agressive()
    {
        //if player is in agressive range walk towards player + walk animation
        agent.SetDestination(player.position);
        anim.Play("Walk00");
    }

    private void Fight() 
    {

        int damage = 2;
        //fight logic

        //walk to and look to player
        agent.SetDestination(transform.position);
        transform.LookAt(player);


        //



        //attack delay
        currentPlayerHealth.currentPlayerHealth -= damage;
         //delay
        //again
        //


        //animation
        anim.Play("Attack00");

    }

    public void DoDamage()
    {
       
        currentEnemyHealth --;
            
        Debug.Log(currentEnemyHealth);

    }


}
