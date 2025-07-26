using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maintower : MonoBehaviour
{
    [SerializeField] public int _health;

    void Update()
    {
        if (_health <= 0)
        {
            Debug.Log("Game Over");
        }
    }
}
