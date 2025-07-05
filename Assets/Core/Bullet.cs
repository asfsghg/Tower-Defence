using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] public int _damage = 10;
    private GameObject target;
    private float _destroyTime = 1f;

    private void OnTriggerEnter(Collider other)
    {

        if (other.TryGetComponent<Monster>(out var player))
        {
            player._health -= _damage;
            Destroy(gameObject);
            Debug.Log(player._health);
            if (player._health <= 0)
            {
                Destroy(player.gameObject);
            }

        }
    }

    void Update()
    {
        if (_destroyTime <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            _destroyTime -= Time.deltaTime;
            Debug.Log(_destroyTime);
        }
    }
}

