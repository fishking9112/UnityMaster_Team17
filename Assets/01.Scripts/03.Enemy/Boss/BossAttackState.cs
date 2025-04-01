using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackState : BossBaseState
{
    public BossAttackState(BossStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

        StartAnimation(stateMachine.Boss.AnimationData.AttackParameterHash);

        ShootToPlayer();
    }

    public override void Exit()
    {
        base.Exit();

        StopAnimation(stateMachine.Boss.AnimationData.AttackParameterHash);
    }

    void ShootToPlayer()
    {
        if (stateMachine.Boss.IsRightArm && stateMachine.Boss.LastGunAttack + stateMachine.Boss.GunRate < Time.time)
        {
            stateMachine.Boss.Riffle();
        }
        else
        {
            stateMachine.Boss.Rocket();
        }
    }
}
