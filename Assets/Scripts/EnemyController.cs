using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private float lookRadius = 10f;

    private Transform target;
    private NavMeshAgent agent;
    private Stats stats;

    private void Start()
    {
        target = GameManager.instance.GetPlayer().transform;
        agent = GetComponent<NavMeshAgent>();
        stats = GetComponent<Enemy>();
    }

    private void Update()
    {
        if (stats.isDead) return;
        float distance = Vector3.Distance(target.position, transform.position);

        if(distance <= lookRadius)
        {
            agent.SetDestination(target.position);

            if(distance <= agent.stoppingDistance)
            {
                FaceTarget();
            }
        }
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }


    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
