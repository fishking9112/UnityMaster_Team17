using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMiliAttackState : BossBaseState
{
    public BossMiliAttackState(BossStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

        StartAnimation(stateMachine.Boss.AnimationData.AttackParameterHash);

        if(Random.Range(0,2) == 0)
        {
            TriggerAnimation(stateMachine.Boss.AnimationData.IsLeftFootParameterHash);
        }
        else
        {
            TriggerAnimation(stateMachine.Boss.AnimationData.IsRightFootParameterHash);
        }

        stateMachine.Boss.InvokeMiliAttack();
    }

    public override void Exit()
    {
        base.Exit();

        StopAnimation(stateMachine.Boss.AnimationData.AttackParameterHash);
    }
}
