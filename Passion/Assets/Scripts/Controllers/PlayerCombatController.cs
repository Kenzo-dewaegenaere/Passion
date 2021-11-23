using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerCombatController : MonoBehaviour
{

    //get enemy health
    public GameObject playerHealth;
    //private NpcAiController currentEnemyHealth;

    //declare range on enemy player has to be in, to set bool false or true
    public float inAttackRange;
    private bool playerInFightRange;

    //enemy tag/layer
    public LayerMask isEnemy;

    //damage
    public int damage = 10;

    private int enemyHp;


    public float cooldown = 1f; //seconds
    private float lastAttackedAt = -9999f;
    public float spellCooldown = 2f; 
    void Start()
    {
        //get the health
        //currentEnemyHealth = playerHealth.GetComponent<NpcAiController>();
    }


    private void Update()
    {

        //if in fight range set to true
        playerInFightRange = Physics.CheckSphere(transform.position, inAttackRange, isEnemy);


        
        //if in fight range run code
        if (playerInFightRange)
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, inAttackRange, isEnemy);
            foreach (var hitCollider in hitColliders)
            {


                GameObject enemy = hitCollider.gameObject;
               
                EnemyAiController enemyHealth = enemy.GetComponent<EnemyAiController>();



                if(Input.GetMouseButtonDown(0))
                {
                   
                    if (Time.deltaTime > lastAttackedAt + cooldown)
                    {
                        enemyHealth.DoDamage();
                        lastAttackedAt = Time.time;
                        
                    }
                   
                }

                if (Input.GetKeyDown(KeyCode.X))
                {

              
                        Rigidbody rb = enemy.GetComponent<Rigidbody>();
                        if (Time.time > lastAttackedAt + spellCooldown)
                        {
                            rb.isKinematic = false;
                            rb.AddForce(transform.forward * 10, ForceMode.Impulse);
                            enemyHealth.Kill();
                            lastAttackedAt = Time.time;

                        }
                    

                   

                }


                

            }
        }
        else
        {
            //if in not fight range
            //Debug.Log("not attackable");
        }



    }

    public void TestSpell()
    {

        playerInFightRange = Physics.CheckSphere(transform.position, inAttackRange, isEnemy);

        if (playerInFightRange)
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, inAttackRange, isEnemy);
            foreach (var hitCollider in hitColliders)
            {

                GameObject enemy = hitCollider.gameObject;
                EnemyAiController enemyHealth = enemy.GetComponent<EnemyAiController>();

                    Rigidbody rb = enemy.GetComponent<Rigidbody>();
                    if (Time.time > lastAttackedAt + spellCooldown)
                    {
                        rb.isKinematic = false;
                        rb.AddForce(transform.forward * 10, ForceMode.Impulse);
                        enemyHealth.Kill();
                        lastAttackedAt = Time.time;

                    }
            }
        }
        else
        {
            //if in not fight range
            //Debug.Log("not attackable");
        }
    }

}


