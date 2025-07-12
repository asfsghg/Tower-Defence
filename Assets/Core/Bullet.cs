using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage = 10;
    [SerializeField] private float _destroyTime = 1f;
    [SerializeField] private ParticleSystem _explodeParticles;

    void Start()
    {
        _explodeParticles.Play();
        Destroy(gameObject, _destroyTime);
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.TryGetComponent(out EnemyHealth enemy))
        {
           enemy.TakeDamage(_damage);
           Destroy(gameObject);
        }
    }


}

