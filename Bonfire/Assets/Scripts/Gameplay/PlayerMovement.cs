﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private float gravityScale = 1.0f;
    private static float globalGravity = -9.81f;
    private Animator anim;
    public PlayerControls playerControls;
    [SerializeField] private float _speed;
    private Vector2 move;
    private bool jump = false;
    private Rigidbody rb;
    [SerializeField] private float jumpForce;
    private bool isTouchingGround;

    
    private void OnEnable()
    {
        playerControls.PlayerMovement.Enable();
    }

    private void OnDisable()
    {
        playerControls.PlayerMovement.Disable();
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerControls = new PlayerControls();
        anim = GetComponentInChildren<Animator>();
        playerControls.PlayerMovement.Movement.performed += ctx => { move = ctx.ReadValue<Vector2>(); };
        playerControls.PlayerMovement.Movement.canceled += ctx => { move = Vector2.zero; };
        playerControls.PlayerMovement.Jumping.performed += ctx => { jump = true; };
    }


    private void FixedUpdate()
    {

        transform.position += new Vector3(move.x, 0, move.y) * Time.deltaTime * _speed;
        if (new Vector3(move.x, 0, move.y) != Vector3.zero)
        {
            transform.forward = new Vector3(move.x, 0, move.y).normalized;
        }

        if (jump && isTouchingGround)
        {
            
            anim.SetBool("Jump", true);
            Jump();
        }
        else if (!jump && isTouchingGround)
        {
            anim.SetBool("Jump", false);
        }
    }

    void Update()
    {
        if (move.magnitude > 0)
        {
            anim.SetTrigger("Walking");
        }
        else 
        {
            anim.SetTrigger("Idle");
        }

        Vector3 gravity = globalGravity * gravityScale * Vector3.up;
        GetComponent<Rigidbody>().AddForce(gravity, ForceMode.Acceleration);
    }

    void Jump()
    {
        anim.SetTrigger("Jump");
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "floor")
        {
            jump = false;
            isTouchingGround = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.transform.tag == "floor")
        {
            isTouchingGround = false;
        }
    }

}