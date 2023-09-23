using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : Stats
{

    [SerializeField]
    private float moveSpeed = 1f;
    private float aim;
    private float damage;
    private Rigidbody m_rb;

    private void Awake()
    {
        m_rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {

    }

    
    private void Update()
    {
    }

}
