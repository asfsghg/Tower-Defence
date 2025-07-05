using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    [SerializeField] private int _health = 100;
    [SerializeField] private int _Speed = 4;
    private NavMeshAgent agent;
    private Transform targetTurret;
    
    private int currentIndex = 0;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
        agent.SetDestination(targetPoints[0].position);
    }
    
 [SerializeField] private Transform[] targetPoints;
    private void Movement()
    {
        if (agent.remainingDistance < 0.01f)
        {
            currentIndex++;
            if (currentIndex >= targetPoints.Length)
            {
                currentIndex = 0;
            }
            agent.destination = targetPoints[currentIndex].position;
        }
    }
    void Update()
    {
            Movement();
            
    }
}
