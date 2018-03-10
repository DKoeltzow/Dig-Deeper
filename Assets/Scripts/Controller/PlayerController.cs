﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float airSpeed;
    [SerializeField]
    private float horizontal;
    [SerializeField]
    private float vertical;
    [SerializeField]
    private float jumpForce;

    private Rigidbody2D rigi;
    private Transform trans;
    private bool jump;
    private bool inAir;
    public GameObject attack;
    public GameObject feet;

    // Use this for initialization
    void Start () {
        rigi = gameObject.GetComponent<Rigidbody2D>();
        trans = gameObject.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxis("Vertical");
        HandleMovement();
        HandleGravity();
    }

    private void Update()
    {
        LookAtMousePos();
        HandleInput();
        if (Input.GetAxis("Fire1")!=0)
        {
            HandleAttack();
        }    
    }

    private void HandleMovement()
    {
        //if (!feet.GetComponent<FootController>().OnGround)
        //{
        //    rigi.velocity += new Vector2(horizontal * airSpeed, 0);
        //    return;
        //}
        rigi.velocity = new Vector2(horizontal * movementSpeed, rigi.velocity.y);
        if(jump)
        {
            rigi.AddForce(new Vector2(0, vertical*jumpForce), ForceMode2D.Impulse);
        }

    }

    //Key Inputs
    private void HandleInput()
    {
        if (vertical != 0)        
            jump = true;        
        else
            jump = false;            
    }

    //stops player from going too high
    private void HandleGravity()
    {
        if (trans.position.y > 2)
        {
            rigi.gravityScale = 1+(1 * trans.position.y);
        }
        else
            rigi.gravityScale = 1;
    }

    private void LookAtMousePos()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = -(mousePos - (Vector2)transform.position).normalized;
        if(direction.y<0)
        {
            direction.y = 0;
        }
        attack.transform.up = direction;
    }

    private void HandleAttack()
    {
        if (feet.GetComponent<FootController>().OnGround)
        {
            attack.GetComponent<AttackController>().Attack();
        } 
    }
}
