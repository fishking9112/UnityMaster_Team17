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
        stateMachine.MovementSpeedModifier = 0f;
        stateMachine.Enemy.agent.speed = stateMachine.MovementSpeed * stateMachine.MovementSpeedModifier;

        base.Enter();
    }

    public override void Exit()
    {
        base.Exit(); 
    }

    public override void Update()
    {
        base.Update();

        stateMachine.Enemy.agent.SetDestination(stateMachine.Enemy.transform.position);

        if (IsInChasingRange() == -1) return;
        else if (IsInChasingRange() <= stateMachine.Enemy.Data.AttackRange)
        {
            if (IsPlayerInSight())
            {
                stateMachine.ChangeState(stateMachine.AttackState);
            }
        }
        else if (IsInChasingRange() <= stateMachine.Enemy.Data.RemainAttackRange)
        {
            if (IsPlayerInSight())
            {
                stateMachine.ChangeState(stateMachine.ChaseState);
            }
        }
        else if (IsInChasingRange() <= stateMachine.Enemy.Data.PlayerChasingRange)
        {
            if(IsPlayerInSight())
            {
                Debug.Log(PlayerSeenTime);
                PlayerSeenTime += Time.deltaTime;
            }
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
