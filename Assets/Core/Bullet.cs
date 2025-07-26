using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage = 10;
    [SerializeField] private float _destroyTime = 1f;
    
    [SerializeField] private int moneyAdd;
  
    


    void Start()
    { 
        
        FindObjectOfType<MoneyController>().moneyText.text = FindObjectOfType<MoneyController>().moneyAmount .ToString();
        Destroy(gameObject, _destroyTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        

        if (other.TryGetComponent(out EnemyHealth enemy))
        {
            FindObjectOfType<MoneyController>().moneyAmount  += moneyAdd;
           enemy.TakeDamage(_damage);
           Destroy(gameObject);
        }
    }


}

