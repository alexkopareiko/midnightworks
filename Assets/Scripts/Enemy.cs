using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyAnimationController))]
public class Enemy : Stats
{
    private EnemyAnimationController enemyAnimationController;

    public override void Start()
    {
        base.Start();
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

        Destroy(this.gameObject, 3f);

    }

}
