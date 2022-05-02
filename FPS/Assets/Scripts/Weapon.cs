using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera fPCamera;
    [SerializeField] float range = 100f;
    //the amount of damage that this gun does
    [SerializeField] float damage = 30;
    // Update is called once per frame 
    [SerializeField] ParticleSystem muzzleFlash; 
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] Ammo ammoType;

    void Update()
    {
        if(Input.GetMouseButtonDown(0)) 
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        //if(ammoSlot.GetCurrentAmmo(ammoType) > 0)
        //{
            ProcessRaycast();
            PlayMuzzleFlash();
            //ammoSlot.ReduceCurrentAmmo(ammoType);
        //}
      
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;

         if(Physics.Raycast(fPCamera.transform.position, fPCamera.transform.forward, out hit, range)) 
        {
             print("I hit this: " + hit.transform.name);

        
            // Hit effect for visual feedback
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();

            target.TakeDamage(damage);
        }
        else 
        {
            return;
        }
    }

    private void PlayMuzzleFlash() 
    {
        muzzleFlash.Play();
    }
       
    private void CreateHitImpact(RaycastHit hit) 
    {
        GameObject impact = Instantiate(hitEffect.gameObject, hit.point, Quaternion.LookRotation(hit.normal)); 
        Destroy(impact, 1.0f);
    }
}
