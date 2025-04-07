using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Skeleton : Enemy
{
    public GameObject foodPrefab;
    [SerializeField] public bool isBoss = false;
    #region States
    public SkeletonIdleState idleState { get; private set; }
    public SkeletonMoveState moveState { get; private set; }
    public SkeletonBattleState battleState { get; private set; }
    public SkeletonAttackState attackState { get; private set; }
    public SkeletonStunnedState stunnedState { get; private set; }
    public SkeletonDeadState deadState { get; private set; }
    public SkeletonAttack2State attack2State { get; private set; }
    #endregion  

    protected override void Awake()
    {
        base.Awake();

        // Inicializa os estados
        idleState = new SkeletonIdleState(this, stateMachine, "Idle", this);
        moveState = new SkeletonMoveState(this, stateMachine, "Move", this);
        battleState = new SkeletonBattleState(this, stateMachine, "Move", this);
        attackState = new SkeletonAttackState(this, stateMachine, "Attack", this);
        attack2State = new SkeletonAttack2State(this, stateMachine, "Attack2", this);
        stunnedState = new SkeletonStunnedState(this, stateMachine, "Stunned", this);
        deadState = new SkeletonDeadState(this, stateMachine, "Idle",this);
      
    }

    protected override void Start()
    {
        base.Start();
       

        stateMachine.Initialize(idleState);
       
    }

    protected override void Update()
    {
        base.Update();

        if(Input.GetKeyDown(KeyCode.U))
        {
            stateMachine.ChangeState(stunnedState);
        }
    }
    public override bool CanBeStunned()
    {
        if(base.CanBeStunned())
        {
            stateMachine.ChangeState(stunnedState);
            return true;
        }
        return false;
    }

    public override void Die()
    {
        base.Die();
        DropItem();

        stateMachine.ChangeState(deadState);
    }

    private void DropItem()
    {
        // Implementação do drop (instancia um item no mundo)
        Instantiate(foodPrefab, transform.position, Quaternion.identity);
    }

}