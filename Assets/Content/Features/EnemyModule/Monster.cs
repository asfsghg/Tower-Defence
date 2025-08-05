using UnityEngine;
using UnityEngine.AI;
using TMPro;
public class Monster : MonoBehaviour
{
    [SerializeField] private int _Speed = 4;
    [SerializeField] private Transform[] targetPoints;
    
    
    

    private NavMeshAgent agent;
    private int currentIndex = 0;

    void Start()
    {
        FindObjectOfType<Maintower>().healthText.text = FindObjectOfType<Maintower>()._health.ToString();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = _Speed;

        if (targetPoints.Length > 0)
            agent.SetDestination(targetPoints[0].position);
    }

    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.1f)
        {
            if (currentIndex >= targetPoints.Length - 1)
            {
                Destroy(gameObject);
                FindObjectOfType<Maintower>()._health -= 10;
                
                FindObjectOfType<Maintower>().healthText.text = FindObjectOfType<Maintower>()._health.ToString();
                FindObjectOfType<Maintower>().textMaxHealth.value = FindObjectOfType<Maintower>()._health;
            }
            else
            {
                currentIndex++;
                agent.SetDestination(targetPoints[currentIndex].position);
            }
        }
    }
}

