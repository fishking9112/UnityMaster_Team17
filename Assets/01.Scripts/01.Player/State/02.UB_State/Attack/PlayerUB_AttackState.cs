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
        UBStateMachine.AttackMode = true;
        UBStateMachine.player.crosshair.enabled = true;
        StartAnimation(LBStateMachine.player.AnimationData.UB_AttackParameterHash);
    }

    public override void Exit()
    {
        base.Exit();

        UBStateMachine.player.AimVCam.Priority = 0;
        UBStateMachine.AttackMode = false;
        UBStateMachine.player.crosshair.enabled = false;
        StopAnimation(LBStateMachine.player.AnimationData.UB_AttackParameterHash);
    }
}
