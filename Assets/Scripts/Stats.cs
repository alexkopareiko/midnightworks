using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    protected float health;
    [SerializeField]
    protected float maxHealth = 10f;

    public bool isDead = false;

    public virtual void Start()
    {
        health = maxHealth;
    }

    public virtual void HealthReduce(float value)
    {
        if (isDead) return;
        health -= value;
        Debug.Log("Health  " + health);
        if (health <= 0) Die();
    }

    public virtual void Die()
    {
        Debug.Log("Dead");
        isDead = true;

    }
}
