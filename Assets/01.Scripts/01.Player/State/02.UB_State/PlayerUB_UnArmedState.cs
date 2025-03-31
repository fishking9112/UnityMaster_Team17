using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUB_UnArmedState : PlayerUB_BaseState
{
    public PlayerUB_UnArmedState(PlayerLBStateMachine LBstateMachine, PlayerUBStateMachine UBStateMachine) : base(LBstateMachine, UBStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(LBStateMachine.player.AnimationData.LB_IdleParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(LBStateMachine.player.AnimationData.LB_IdleParameterHash);
    }

    public override void Update()
    {

    }
}
