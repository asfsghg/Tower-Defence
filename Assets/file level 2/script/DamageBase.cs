using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBase : MonoBehaviour
{

    private Enemy enemy;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Base"))
        {
            BaseHealt baseHealth = other.GetComponent<BaseHealt>();
            if (baseHealth != null && enemy != null)
            {
                baseHealth.TakeDamage(enemy.health);
            }

            Destroy(gameObject); 
        }
    }
}



