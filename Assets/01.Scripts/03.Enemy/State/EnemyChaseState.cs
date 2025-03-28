using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : EnemyBaseState
{
    public EnemyChaseState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }
    public override void Enter()
    {
        stateMachine.MovementSpeedModifier = 1f;
        stateMachine.Enemy.agent.speed = stateMachine.MovementSpeed * stateMachine.MovementSpeedModifier;

        base.Enter();
        StartAnimation(stateMachine.Enemy.AnimationData.ChasingParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Enemy.AnimationData.ChasingParameterHash);
    }

    public override void Update()
    {
        base.Update();

        stateMachine.Enemy.agent.SetDestination(stateMachine.Player.transform.position);

        if (IsInChasingDistance() > stateMachine.Enemy.Data.PlayerChasingRange)
        {
            stateMachine.ChangeState(stateMachine.IdleState);
        }
        else if(IsInChasingRange() <= stateMachine.Enemy.Data.AttackRange)
        {
            if (IsPlayerInSight())
            {
                stateMachine.ChangeState(stateMachine.AttackState);
            }
        }
    }
}
