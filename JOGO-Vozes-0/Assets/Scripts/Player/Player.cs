using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class Player : Entity
{

    [Header("attack details")]
    public Vector2[] attackMovement;
    public float counterAttackDuration = .2f;
   


    public bool isBusy { get; private set; }
    [Header("Move Info")]
    public float jumpForce;
    public float moveSpeed = 12f;

    [Header("Dash info")]
    public float dashSpeed;
    public float dashDuration;
    public float dashDir { get; private set; }




    public SkillManager skill {  get; private set; }




   


   
   
   


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
    public PlayerCounterAttackState CounterAttack { get; private set; }

    public PlayerAimSwordState AimSword { get; private set; }
    public PlayerCatchSwordState catchSword { get; private set; }

    public PlayerDeadState DeadState { get; private set; }
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
        CounterAttack = new PlayerCounterAttackState(this, StateMachine, "CounterAttack");

        AimSword = new PlayerAimSwordState(this, StateMachine, "AimSword");
        catchSword = new PlayerCatchSwordState(this, StateMachine, "CatchSword");

        DeadState = new PlayerDeadState(this, StateMachine, "Die");
        
    }

    protected override void Start()
    {
        base.Start();

        skill = SkillManager.instance;

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




        if (Input.GetKeyDown(KeyCode.LeftShift) && SkillManager.instance.dash.CanUseSkill())
        {
           
            dashDir = Input.GetAxisRaw("Horizontal");

            if (dashDir == 0)
                dashDir = facingDir;

            StateMachine.ChangeState(dashState);
        }
    }



    public override void Die()
    {
        base.Die();

        StateMachine.ChangeState(DeadState);
    }

}
