using System.Collections;
using System.Collections.Generic;
using UnityEngine;public class EnemyAttack : MonoBehaviour
{
    PlayerHealthScript Target;
    [SerializeField] Transform target;
    [SerializeField] float damage = 40f;
    // Start is called before the first frame update
    void Start()
    {
        Target = FindObjectOfType<PlayerHealthScript>();
    } 
       public void AttackHitEvent() 
    {
        if (target == null)
        {
            return;
        }
        print("player has been hit.");
        target.GetComponent<PlayerHealthScript>().TakeDamage(damage);
    }    // Update is called once per frame
}