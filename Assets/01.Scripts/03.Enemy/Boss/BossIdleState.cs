using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdleState : BossBaseState
{
    public BossIdleState(BossStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.Boss.agent.isStopped = true;

        base.Enter();
        StartAnimation(stateMachine.Boss.AnimationData.IdleParameterHash);
        StartAnimation(stateMachine.Boss.AnimationData.StartParameterHash);
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
        
        //근거리 공격
        else if (IsInChasingRange() <= stateMachine.Boss.Data.AttackRange)
        {
            if (IsPlayerInSight())
            {
                stateMachine.ChangeState(stateMachine.MiliAttackState);
            }
        }
        //원거리 공격
        else if (IsInChasingRange() <= stateMachine.Boss.Data.RemainAttackRange)
        {
            if((stateMachine.Boss.IsLeftArm && stateMachine.Boss.LastRocketAttack + stateMachine.Boss.RocketRate < Time.time) && 
                (stateMachine.Boss.IsRightArm && stateMachine.Boss.LastGunAttack + stateMachine.Boss.GunRate < Time.time))
            {
                if (IsPlayerInSight())
                {
                    stateMachine.ChangeState(stateMachine.AttackState);
                }
            }
        }
        else if(IsInChasingDistance() <= stateMachine.Boss.Data.PlayerChasingRange)
        {
            stateMachine.ChangeState(stateMachine.ChaseState);
        }
    }
}
