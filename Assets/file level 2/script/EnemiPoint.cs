using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemiPoint : MonoBehaviour
{
    //private int currentWayPoint;
    // private GameObject[] wayPoint;
    // public float speed;
    // private Vector3 target;
    [SerializeField] private Transform playerPoint;

    private NavMeshAgent agen;

    void Start()
    {
        agen = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        agen.SetDestination(playerPoint.position);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "WayPoint")
        {
            Destroy(gameObject);
            
        }
    }

}
