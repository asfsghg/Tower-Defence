using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class TurretControl : MonoBehaviour
{
    [SerializeField] Transform bulletPrefab;
    [SerializeField] private float rayDistance = 15;
    [SerializeField] private float Radius = 10f;
    private NavMeshAgent agent;
    private Transform targetEnemy;
    [SerializeField] private LayerMask EnemyLayer;
    [SerializeField] private Transform TurretPrefab;
    
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    
    void Update()
    {
        DetectPlayer();
        
                if (targetEnemy != null)
                {
                    
                    Ray ray = new Ray(transform.position, targetEnemy.position - transform.position);
                    TurretPrefab.forward = ray.direction;
                    Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.red);
                    RaycastHit hit;
                    Invoke("Update", 1);
                    
                }
    }
    private void DetectPlayer()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, Radius, EnemyLayer);

        targetEnemy = null; 

        foreach (Collider collider in hitColliders)
        {
            if (collider.TryGetComponent<Monster>(out var player))
            {
                targetEnemy = player.transform;
                break;
            }
        }
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, Radius);
    }
}
