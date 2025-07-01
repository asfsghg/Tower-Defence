using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TurretControl : MonoBehaviour
{
    [SerializeField] Transform bulletPrefab; //префаб кулі
    [SerializeField] private float rayDistance = 15; // дистанція кулі
    [SerializeField] private float Radius = 10f; // радіус зони попадання куль
    private NavMeshAgent agent;
    private Transform targetEnemy; // ворог
    [SerializeField] private LayerMask EnemyLayer; 
    [SerializeField] private Transform TurretPrefab; // префаб турелі
    [SerializeField] private int _bulletSpeed = 10; // швидкість кулі
    [SerializeField] private float _bulletfrequency = 2f; // частота кулі

    private float shootTimer = 0f; // затримка кулі

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update() //функція турелі
    {
        DetectPlayer();

        if (targetEnemy != null)
        {
            Ray ray = new Ray(transform.position, targetEnemy.position - transform.position);
            TurretPrefab.forward = ray.direction; 
            

            shootTimer += Time.deltaTime;

            if (shootTimer >= 1f / _bulletfrequency)
            {
                Shoot(ray.direction);
                shootTimer = 0f;
            }
        }
    }

    private void DetectPlayer() //знаходження ворога
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

    private void Shoot(Vector3 direction) //стрільба
    {
        Transform bullet = Instantiate(bulletPrefab, TurretPrefab.position, Quaternion.identity);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = direction.normalized * _bulletSpeed;
        }
    }

    private void OnDrawGizmosSelected() //радіус знаходження ворога
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, Radius);
    }
}
