using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    private float health;
    [SerializeField]
    private float maxHealth = 10f;
    private bool isDead = false;


    private void Awake()
    {
        health = maxHealth;
    }

    public virtual void HealthReduce(float value)
    {
        Debug.Log("Health reduce");
        health -= value;
        if (health <= 0) Die();
    }

    public virtual void Die()
    {
        Debug.Log("Dead");
        isDead = true;
    }
}
