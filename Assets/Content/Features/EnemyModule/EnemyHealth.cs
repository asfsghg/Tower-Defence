using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] public int _Health = 100;

    public void TakeDamage(int _damage)
    {
        _Health -= _damage;
        if (_Health < 0)
        {
            Destroy(gameObject);
        }
    }
}
