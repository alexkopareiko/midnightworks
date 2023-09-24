using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(EnemyAnimationController))]
public class Enemy : Stats
{
    private EnemyAnimationController enemyAnimationController;
    [SerializeField]
    private Image healthBar;

    public override void Start()
    {
        base.Start();
        enemyAnimationController = GetComponent<EnemyAnimationController>();
    }


    public override void HealthReduce(float value)
    {
        base.HealthReduce(value);
        enemyAnimationController.GetHit();
        healthBar.fillAmount = health / maxHealth;
    }

    public override void Die()
    {
        base.Die();
        enemyAnimationController.Die();

        GameManager.instance.MinusEnemy();

        Destroy(this.gameObject, 3f);

    }


}
