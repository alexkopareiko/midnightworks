using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Stats
{

    [SerializeField]
    private float moveSpeed = 1f;
    private float aim;
    private float damage;
    private Rigidbody m_rb;
    private EnemyAnimationController enemyAnimationController;

    private void Awake()
    {
        m_rb = GetComponent<Rigidbody>();
        enemyAnimationController = GetComponent<EnemyAnimationController>();
    }

    public override void HealthReduce(float value)
    {
        base.HealthReduce(value);
        enemyAnimationController.GetHit();
    }

    public override void Die()
    {
        base.Die();
        enemyAnimationController.Die();
    }

}
