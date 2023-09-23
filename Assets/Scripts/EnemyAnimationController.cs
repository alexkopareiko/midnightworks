using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimationController : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent agent;

    private void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        animator.SetFloat("MotionSpeed", agent.velocity.magnitude);
    }

    public void GetHit()
    {
        animator.Play("GetHit");
    }
    
    public void Die()
    {
        animator.SetBool("Dead", true);
    }
}
