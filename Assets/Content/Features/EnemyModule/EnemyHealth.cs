using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] Slider textHealth;
    [SerializeField] public int _Health = 100;

    private void Awake()
    {
        if (textHealth != null)
            textHealth.value = _Health;
    }
    public void TakeDamage(int _damage)
    {
        
        _Health -= _damage;
       if (textHealth != null)
            textHealth.value = _Health;
        if (_Health < 0)
        {
            
            Destroy(gameObject);
            
        }
    }
}
