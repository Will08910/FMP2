using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Movement : MonoBehaviour
{
    public NavMeshAgent agent;
    public float range;
    public bool isPlayerInRange;


    public Transform centrePoint;
    public Transform player;

    
    public float normalSpeed = 3.5f;  
    
    public float chaseSpeed = 12f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = normalSpeed;  
    }

    
    void Update()
    {
        if (isPlayerInRange && player != null)
        {
            
            agent.SetDestination(player.position);
        }
        else if (!isPlayerInRange && agent.remainingDistance <= agent.stoppingDistance)
        {
            
            Vector3 point;
            if (RandomPoint(centrePoint.position, range, out point))
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
                agent.SetDestination(point);
            }
        }
    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        Vector3 randomPoint = center + Random.insideUnitSphere * range;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            player = other.transform;
            isPlayerInRange = true;

            
            agent.ResetPath();
            agent.SetDestination(player.position); 

            
            agent.speed = chaseSpeed;  
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            isPlayerInRange = false;
            player = null;

            
            agent.speed = normalSpeed;  
        }
    }
}
