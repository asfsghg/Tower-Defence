using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    [SerializeField] private Transform[] targetPoints;
    
    private NavMeshAgent agent;
    
    private int currentIndex = 0;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
        agent.SetDestination(targetPoints[0].position);
    }
    

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
