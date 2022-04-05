using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class EnemyAI : MonoBehaviour
{ 
    //Target will be player
    [SerializeField] Transform target;

    //How close can Player get to enemy before chased
    [SerializeField] float chaseRange = 5.0f;

    NavMeshAgent nMA;

    //how far the enemy AI can look for player
    float distancetoTarget = Mathf.Infinity;

    bool isProvoked = false;

    // Start is called before the first frame update
    void Start()
    {
        nMA = GetComponent<NavMeshAgent>(); 
    }

    // Update is called once per frame
    /*void Update()
    {
        //measure distance between enemy and player
        distancetoTarget = Vector3.Distance(target.position, transform.position); 

        if(distancetoTarget <= chaseRange)
        {
            nMA.SetDestination(target.position);
        }

       
    }*/

    void Update()
    {

        //measure distance between enemy and player
        distancetoTarget = Vector3.Distance(target.position, transform.position);

        if (isProvoked) 
        {
            EngageTarget();
        }

        else if (distancetoTarget <= chaseRange)
        {
           isProvoked = true;
        }
        
    }
    private void EngageTarget()
    {
        if (distancetoTarget >= nMA.stoppingDistance)
        {
            ChaseTarget();
        }
        if (distancetoTarget <= nMA.stoppingDistance)
        {
            AttackTarget();
        }

    }

    private void ChaseTarget()
    {
        GetComponent<Animator>().SetTrigger("run");
        nMA.SetDestination(target.position);
         GetComponent<Animator>().SetBool("attack", false);
    }


    private void AttackTarget()
    { 
       GetComponent<Animator>().SetBool("attack", true);
        //temp for now 
        //print(name + "is attacking" + target.name);

    }

    private void OnDrawGizmosSelected()
    {
        // Display the chase range when selected 
        Gizmos.color = new Color(1,0,0,1.0f); //choose color 
        Gizmos.DrawWireSphere(transform.position, chaseRange);


    }



}



