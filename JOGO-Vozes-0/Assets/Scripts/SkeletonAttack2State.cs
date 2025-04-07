using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAttack2State : EnemyState
{
    private Enemy_Skeleton enemy;

    public SkeletonAttack2State(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Skeleton enemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
        enemy.SetZeroVelocity();
    }

    public override void Exit()
    {
        base.Exit();
        enemy.lastTimeAttack = Time.time;
        enemy.SetZeroVelocity();
    }

    public override void Update()
    {
        base.Update();

        enemy.SetZeroVelocity();
        if (triggerCalled)
            stateMachine.ChangeState(enemy.idleState);
    }
}
