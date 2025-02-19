using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    public PlayerGroundedState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    } 

    public override void update()
    {
        base.update();

        if (Input.GetKeyDown(KeyCode.Mouse0))
            stateMachine.ChangeState(player.PrimaryAttack);


        if (!player.isGroundDetected())

            stateMachine.ChangeState(player.airState);


        if (Input.GetKeyDown(KeyCode.Space) && player.isGroundDetected())
            stateMachine.ChangeState(player.JumpState);

        

    }

  
}
