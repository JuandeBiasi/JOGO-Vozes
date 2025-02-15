using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.XR;

public class Player : Entity
{
    
        
    [Header ("Move info")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;

    [Header("Dash Info")]
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashDuration;
                     private float dashTime;

    [SerializeField] private float dashCooldown;
                     private float dashCooldownTimer;

    [Header("Attack info")]
   [SerializeField] private float comboTime = .3f;
    private float comboTimeWindow;
    private bool isAttacking;
    private int comboCounter;




    private float xInput;

    

   
    


    protected override void Start()
    {
        base.Start();
    }


    // Start is called before the first frame update


    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        Movement();
        CheckInput();
        CollisionChecks();

        dashTime -= Time.deltaTime;
        dashCooldownTimer -= Time.deltaTime;
        comboTimeWindow -= Time.deltaTime;


        if (dashTime > 0)
        {
           
        }

        FlipContoller();
        AnimatorController();
    }

    public void AttackOver()
    {
        isAttacking = false;


        comboCounter++;

        if (comboCounter > 2)
            comboCounter = 0;

       


    }

  

    private void CheckInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartAttackEvent();
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }


        if (Input.GetKeyDown(KeyCode.LeftShift) )
        {
            DashAbility();

        }
    }

    private void StartAttackEvent()
    {
        if (!isGrounded)
            return;


        if (comboTimeWindow < 0)
            comboCounter = 0;


        isAttacking = true;
        comboTimeWindow = comboTime;
    }

    private void DashAbility()
    {
        if (dashCooldownTimer < 0 && !isAttacking)
        {

            dashCooldownTimer = dashCooldown;
            dashTime = dashDuration;
        }
    }

    private void Movement()
    {
        if (isAttacking)
        {
            rb.velocity = new Vector2(0, 0);
        }


       else if (dashTime >0)
        {
            rb.velocity = new Vector2(facingDir * dashSpeed, 0);
        }
        else
        {
            rb.velocity = new Vector2(xInput * moveSpeed, rb.velocity.y);
        }

    }

    private void Jump()
    {
        if (isGrounded)
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void AnimatorController()
    {
       bool isMoving = rb.velocity.x != 0;

        anim.SetFloat("yVelocity", rb.velocity.y);

        anim.SetBool("isMoving", isMoving);
        anim.SetBool("IsGrounded", isGrounded);
        anim.SetBool("isDashing", dashTime > 0);
        anim.SetBool("isAttacking", isAttacking);
        anim.SetInteger("comboCounter", comboCounter);
    }
 

    private void FlipContoller()
    {
        if (rb.velocity.x > 0 && !facingRight)
        
            Flip();
        
        else if (rb.velocity.x < 0 && facingRight)
            Flip(); 
        
       
    }

   
}
