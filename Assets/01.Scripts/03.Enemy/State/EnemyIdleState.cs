using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
    float PlayerSeenTime = 0;

    public EnemyIdleState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        //캐릭터 속도 조정
        stateMachine.MovementSpeedModifier = 0f;
        stateMachine.Enemy.agent.speed = stateMachine.MovementSpeed * stateMachine.MovementSpeedModifier;

        //제자리에 멈추도록 제작
        stateMachine.Enemy.agent.SetDestination(stateMachine.Enemy.transform.position);

        base.Enter();
    }

    public override void Exit()
    {
        base.Exit(); 
    }

    public override void Update()
    {
        base.Update();

        //범위 밖이면 인식을 못한다
        if (IsInChasingRange() == -1) return;

        //공격 범위 내면서 시야 내면 즉시 공격
        else if (IsInChasingRange() <= stateMachine.Enemy.Data.AttackRange)
        {
            if (IsPlayerInSight())
            {
                stateMachine.ChangeState(stateMachine.AttackState);
            }
        }

        //일정 거리 내면서 시야 내면 즉시 추적
        else if (IsInChasingRange() <= stateMachine.Enemy.Data.RemainAttackRange)
        {
            if (IsPlayerInSight())
            {
                stateMachine.ChangeState(stateMachine.ChaseState);
            }
        }

        //먼 거리에서 시야 내면 시간을 준 후 추적
        else if (IsInChasingRange() <= stateMachine.Enemy.Data.PlayerChasingRange)
        {
            if(IsPlayerInSight())
            {
                PlayerSeenTime += Time.deltaTime;
            }
            //시야 밖이면 점차 의심도 감소
            else
            {
                if (PlayerSeenTime > 0)
                {
                    PlayerSeenTime -= Time.deltaTime;
                }
                else
                {
                    PlayerSeenTime = 0;
                }
            }

            if (PlayerSeenTime >= 2)
            {
                PlayerSeenTime = 0;
                stateMachine.ChangeState(stateMachine.ChaseState);
            }
        }
    }
}
