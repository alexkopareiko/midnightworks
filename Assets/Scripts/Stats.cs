using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    private float health;
    [SerializeField]
    private float maxHealth = 10f;

    public bool isDead = false;


    private void Start()
    {
        health = maxHealth;
    }

    public virtual void HealthReduce(float value)
    {
        if (health <= 0) return;
        health -= value;
        Debug.Log("Health  " + health);
        if (health <= 0) Die();
    }

    public virtual void Die()
    {
        Debug.Log("Dead");
        isDead = true;

        Destroy(this.gameObject, 3f);
    }
}
