using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

[RequireComponent(typeof(EnemyAnimationController))]
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Stats))]
public class EnemyCombatController : MonoBehaviour
{
    [SerializeField]
    private float attackDelay = 1f;
    private float attackDelayTimer;
    [SerializeField]
    private float damage = 1f;

    private Transform target;
    private NavMeshAgent agent;
    private Stats stats;
    private EnemyAnimationController enemyAnimationController;

    private void Start()
    {
        target = GameManager.instance.GetPlayer().transform;
        agent = GetComponent<NavMeshAgent>();
        stats = GetComponent<Enemy>();
        enemyAnimationController = GetComponent<EnemyAnimationController>();
    }

    private void Update()
    {
        if (stats.isDead) return;
        if (target == null) return;
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= agent.stoppingDistance && attackDelayTimer <= 0)
        {
            Attack();
        }

        if (attackDelayTimer > 0) attackDelayTimer -= Time.deltaTime;
    }

    private void Attack()
    {
        target.GetComponent<Player>().HealthReduce(damage);
        enemyAnimationController.Attack();
        attackDelayTimer = attackDelay;
    }

}
