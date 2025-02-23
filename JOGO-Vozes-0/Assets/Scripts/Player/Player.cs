using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class Player : Entity
{

    [Header("attack details")]
    public Vector2[] attackMovement;


    public bool isBusy { get; private set; }
    [Header("Move Info")]
    public float jumpForce;
    public float moveSpeed = 12f;

    [Header("Dash info")]
    [SerializeField] private float dashCoolDown;
    private float dashUsageTimer;
    public float dashSpeed;
    public float dashDuration;
    public float dashDir { get; private set; }







   


   
   
   


    #region States
    public PlayerStateMachine StateMachine { get; private set; }
    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerAirState airState { get; private set; }
    public PlayerDashState dashState { get; private set; }
    public PlayerWallSlideState wallSlide { get; private set; }
    public PlayerWallJumpState wallJump { get; private set; }
    public PlayerPrimaryAttackState PrimaryAttack { get; private set; }
    #endregion
   protected override void Awake()
    {
        base.Awake();
        StateMachine = new PlayerStateMachine();

        idleState = new PlayerIdleState(this, StateMachine, "Idle");
        MoveState = new PlayerMoveState(this, StateMachine, "Move");
        JumpState = new PlayerJumpState(this, StateMachine, "Jump");
        airState = new PlayerAirState(this, StateMachine, "Jump");
        dashState = new PlayerDashState(this, StateMachine, "Dash");
        wallSlide = new PlayerWallSlideState(this, StateMachine, "WallSlide");
        wallJump = new PlayerWallJumpState(this, StateMachine, "Jump");
        PrimaryAttack = new PlayerPrimaryAttackState(this, StateMachine, "Attack");
    }

    protected override void Start()
    {
        base.Start();


        StateMachine.Initialize(idleState);

    }

    protected override void Update()
    {
        base.Update();

        StateMachine.currentState.update();

        CheckforDashintput();

    }

    public IEnumerator BusyFor(float _seconds)
    {
        isBusy = true;
       

        yield return new WaitForSeconds(_seconds);

        
        isBusy = false;
    }


    public void animationTtrigger() => StateMachine.currentState.AnimationFinishTrigger(); 

    private void CheckforDashintput()
    {
        if (IsWallDetected())
            return;

        dashUsageTimer -= Time.deltaTime;


        if (Input.GetKeyDown(KeyCode.LeftShift) && dashUsageTimer < 0 )
        {
            dashUsageTimer = dashCoolDown;
            dashDir = Input.GetAxisRaw("Horizontal");

            if (dashDir == 0)
                dashDir = facingDir;

            StateMachine.ChangeState(dashState);
        }
    }

 
   
    

}
