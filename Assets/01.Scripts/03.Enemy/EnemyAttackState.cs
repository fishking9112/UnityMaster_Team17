using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
    public EnemyAttackState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }
    public override void Enter()
    {
        stateMachine.MovementSpeedModifier = 0f;

        base.Enter();
        StartAnimation(stateMachine.Enemy.AnimationData.ShootParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Enemy.AnimationData.ShootParameterHash);
    }

    public override void Update()
    {
        base.Update();

        if (!IsPlayerInSight() || IsInChasingDistance() > stateMachine.Enemy.Data.RemainAttackRange)
        {
            stateMachine.ChangeState(stateMachine.ChaseState);
        }
    }
}
