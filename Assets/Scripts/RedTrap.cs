using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedTrap : MonoBehaviour
{
    public int damageAmount = 1;

    void OnTriggerEnter(Collider other)
    {
      if(other.CompareTag("Player")){
        HealthSystem hp = other.GetComponent<HealthSystem>();

        if(hp!=null){
            hp.TakeDamage(damageAmount);
            
        }
      }  
    }
}
