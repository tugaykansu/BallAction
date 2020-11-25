using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPoint : MonoBehaviour
{
    [SerializeField] private float movePower = 3; // The force added to the ball to move it.
    [SerializeField] private float maxAngularVelocity = 15; // The maximum velocity the ball can rotate at.
    
    private Rigidbody rb;
    private Transform center; // A reference to the center point in the scenes transform
    private Vector3 moveDirection;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = maxAngularVelocity;
        center = GameObject.FindGameObjectWithTag("Respawn").transform;
    }

    private void Update()
    {
        moveDirection = Vector3.Cross(transform.position - center.transform.position, Vector3.up);
    }

    private void FixedUpdate()
    {
        rb.AddTorque(moveDirection*movePower);
    }

    public void ScaleMovePower(float movePower)
    {
        this.movePower *= movePower;
    }
    
    public void ScaleMaxAngularVelocity(float maxAngularVelocity)
    {
        this.maxAngularVelocity *= maxAngularVelocity;
    }
}
