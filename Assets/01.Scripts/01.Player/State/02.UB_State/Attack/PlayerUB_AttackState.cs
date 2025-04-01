using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUB_AttackState : PlayerUB_BaseState
{
    public PlayerUB_AttackState(PlayerLBStateMachine LBstateMachine, PlayerUBStateMachine UBStateMachine) : base(LBstateMachine, UBStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

        UBStateMachine.player.AimVCam.Priority = 20;
        StartAnimation(LBStateMachine.player.AnimationData.UB_AttackParameterHash); // 수정해야함.
    }

    public override void Exit()
    {
        base.Exit();

        UBStateMachine.player.AimVCam.Priority = 0;
        StopAnimation(LBStateMachine.player.AnimationData.UB_AttackParameterHash);
    }
}
