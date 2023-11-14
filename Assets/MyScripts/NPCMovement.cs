using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//场景1、2，NPC随机移动
public class NPCMovement : MonoBehaviour
{
    public float wanderRadius = 10f;
    public float wanderTimer = 5f;

    private Vector3 target;
    private NavMeshAgent agent;
    private float timer;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
        GetNewDestination();
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            GetNewDestination();
            timer = wanderTimer;
        }

        if (agent != null && !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            GetNewDestination();
        }
    }

    private void GetNewDestination()
    {
        Vector3 randomPoint = Random.insideUnitSphere * wanderRadius;
        randomPoint += transform.position;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, wanderRadius, NavMesh.AllAreas))
        {
            target = hit.position;
            agent.SetDestination(target);
        }
    }
}