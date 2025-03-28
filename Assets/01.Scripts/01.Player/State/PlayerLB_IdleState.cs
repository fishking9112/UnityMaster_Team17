using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLB_IdleState : PlayerLB_GroundedState
{
    public PlayerLB_IdleState(PlayerLBStateMachine stateMachine, PlayerUBStateMachine UBStateMachine) : base(stateMachine, UBStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(LBstateMachine.player.AnimationData.IdleParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(LBstateMachine.player.AnimationData.IdleParameterHash);
    }
}
