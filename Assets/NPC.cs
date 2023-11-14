using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NPC : MonoBehaviour
{
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetDestination();
    }

    private void Update()
    {
        if (agent != null && agent.isActiveAndEnabled && agent.isOnNavMesh)
        {
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                SetDestination();
            }
        }
    }

    private void SetDestination()
    {
        if (agent != null && agent.isActiveAndEnabled && agent.isOnNavMesh)
        {
            Vector3 destination = new Vector3(Random.Range(-10f, 10f), 0f, Random.Range(-10f, 10f));
            agent.SetDestination(destination);
        }
    }


}