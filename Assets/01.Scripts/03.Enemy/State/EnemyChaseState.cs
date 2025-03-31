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
        //추적 속도
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

        //플레이어를 지속 추적
        stateMachine.Enemy.agent.SetDestination(stateMachine.Player.transform.position);

        //플레이어와 적의 거리가 일정 이상이면 정지(각도 X))
        if (IsInChasingDistance() > stateMachine.Enemy.Data.PlayerChasingRange)
        {
            stateMachine.ChangeState(stateMachine.IdleState);
        }
        //일정범위 내에 시야 내면 공격
        else if(IsInChasingRange() <= stateMachine.Enemy.Data.AttackRange)
        {
            if (IsPlayerInSight())
            {
                stateMachine.ChangeState(stateMachine.AttackState);
            }
        }
    }
}
