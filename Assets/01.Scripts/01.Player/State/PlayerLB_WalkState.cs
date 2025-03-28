using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLB_WalkState : PlayerLB_GroundedState
{
    public PlayerLB_WalkState(PlayerLBStateMachine LBstateMachine, PlayerUBStateMachine UBStateMachine) : base(LBstateMachine, UBStateMachine)
    {
    }

    public override void Enter()
    {
        name = "Walk";
        LBStateMachine.MovementSpeedModifier = LBStateMachine.player.playerSO.GroundData.WalkSpeed;
        animationSpeedModifier = 4f;
        Debug.Log($"Enter:{animationSpeedModifier}");
        base.Enter();
        StartAnimation(LBStateMachine.player.AnimationData.LB_WalkParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(LBStateMachine.player.AnimationData.LB_WalkParameterHash);
    }
}
