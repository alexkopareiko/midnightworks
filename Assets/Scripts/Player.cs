using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Stats
{
    private PlayerAnimationController playerAnimationController;

    public override void Start()
    {
        base.Start();
        playerAnimationController = GetComponent<PlayerAnimationController>();
    }

    public override void HealthReduce(float value)
    {
        base.HealthReduce(value);
        playerAnimationController.GetHit();
    }

    public override void Die()
    {
        base.Die();
        playerAnimationController.Die();
    }
}
