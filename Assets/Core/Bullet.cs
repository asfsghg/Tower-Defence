using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int damage = 10;
    [SerializeField] private float _destroyTime = 1f;

    void Start()
    {
        Destroy(gameObject, _destroyTime);
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.TryGetComponent(out EnemyHealth enemy))
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);

        }
    }
    
}

