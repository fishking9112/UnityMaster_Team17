using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLB_RunState : PlayerLB_GroundedState // 미사용
{
    public PlayerLB_RunState(PlayerLBStateMachine LBstateMachine, PlayerUBStateMachine UBStateMachine) : base(LBstateMachine, UBStateMachine)
    {
    }

    public override void Enter()
    {
        LBStateMachine.MovementSpeedModifier = LBStateMachine.player.playerSO.GroundData.RunSpeed;
        animationSpeedModifier = 4f;
        base.Enter();
        StartAnimation(LBStateMachine.player.AnimationData.LB_RunParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(LBStateMachine.player.AnimationData.LB_RunParameterHash);
    }
}
