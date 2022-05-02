using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthScript : MonoBehaviour
{    [SerializeField] float hitPoints = 100f;
    // Start is called before the first frame update
    public void TakeDamage(float damage)
    {
        hitPoints -= damage;        if (hitPoints <= 0)
        {
            print("you die");
            GetComponent<DeathHandlerScript>().ProcessDeath();
        }
    }
}