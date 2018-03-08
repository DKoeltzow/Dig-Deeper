using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float airSpeed;
    [SerializeField]
    private float verSpeed;

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
        HandleGravity();
        float horizontal = Input.GetAxisRaw("Horizontal");
        HandleMovement(horizontal, jump);
    }

    private void Update()
    {
        LookAtMousePos();
        HandleInput();
        if (Input.GetMouseButton(0))
        {
            HandleAttack();
        }    
    }

    private void HandleMovement(float hor,bool jump)
    {
        if (!feet.GetComponent<FootController>().OnGround)
        {
            rigi.velocity += new Vector2(hor * airSpeed, 0);
            return;
        }
        rigi.velocity = new Vector2(hor * movementSpeed, rigi.velocity.y);
        if (feet.GetComponent<FootController>().OnGround && jump)
        {
            rigi.AddForce(new Vector2(0, verSpeed), ForceMode2D.Impulse);
        }

    }

    //Key Inputs
    private void HandleInput()
    {
        jump = Input.GetKey(KeyCode.W);
    }

    //stops player from going too high
    private void HandleGravity()
    {
        if (trans.position.y > 2)
        {
            rigi.gravityScale = 1+(1 * trans.position.y/20);
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
        attack.GetComponent<AttackController>().Attack();
        Debug.Log("Attack");
    }
}
