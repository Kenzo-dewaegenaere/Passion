using System.Collections;
using System.Collections.Generic;
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

   
    void Start()
    {
        //get the health
        //currentEnemyHealth = playerHealth.GetComponent<NpcAiController>();
    }


    private void Update()
    {

        int damage = 10;

        //if in fight range set to true


        playerInFightRange = Physics.CheckSphere(transform.position, inAttackRange, isEnemy);


        
        //if in fight range run code
        if (playerInFightRange)
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, inAttackRange, isEnemy);
            foreach (var hitCollider in hitColliders)
            {

                enemyHp = hitCollider.gameObject.GetComponent<NpcAiController>().currentEnemyHealth;
   
                Debug.Log(enemyHp);
            }
        }
        else
        {
            //if in not fight range
            //Debug.Log("not attackable");
        }



    }
}


