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
        if (stateMachine.Boss.IsRightArm && stateMachine.Boss.LastGunAttack + stateMachine.Boss.GunRate < Time.time)
        {

        }
        else
        {

        }

        base.Enter();

        StartAnimation(stateMachine.Boss.AnimationData.AttackParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
    }
}
