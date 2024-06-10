using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class daohang : MonoBehaviour
{
    public Transform[] targetPoints; // 目标点数组
    private int currentTargetIndex = 0; // 当前目标点的索引
    private UnityEngine.AI.NavMeshAgent agent; // NavMesh代理

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        if (targetPoints.Length > 0)
        {
            SetNextTarget();
        }
    }

    void SetNextTarget()
    {
        if (currentTargetIndex < targetPoints.Length)
        {
            agent.SetDestination(targetPoints[currentTargetIndex].position);
        }
    }

    void Update()
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            currentTargetIndex++;
            if (currentTargetIndex < targetPoints.Length)
            {
                SetNextTarget();
            }
        }
    }

}
