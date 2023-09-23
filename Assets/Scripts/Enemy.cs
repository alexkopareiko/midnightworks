using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : Stats
{
    [SerializeField]
    private float detectZoneRadius;
    [SerializeField]
    private float moveSpeed = 1f;
    private float aim;
    private float damage;
    private Rigidbody m_rb;

    private void Awake()
    {
        m_rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Perform a sphere raycast.
        RaycastHit hit;
        if (Physics.SphereCast(transform.position, detectZoneRadius, transform.forward, out hit))
        {
            // The raycast hit a collider.
            if(hit.collider.tag == "Player")
            {
                float distance = Vector3.Distance(hit.collider.transform.position, transform.position);
                Vector3 direction = hit.collider.transform.position - transform.position;
                if(distance > 1f)
                {
                    m_rb.velocity = direction * moveSpeed;
                }
                //transform.forward = Vector3.Lerp(transform.forward, direction, Time.deltaTime * 20f);
                float angle = Vector3.Angle(transform.forward, direction);
                transform.Rotate(Vector3.up, angle);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        //Gizmos.DrawSphere(transform.position, detectZoneRadius);
    }
}
