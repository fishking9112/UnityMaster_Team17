using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLB_IdleState : PlayerLB_GroundedState
{
    public PlayerLB_IdleState(PlayerLBStateMachine LBstateMachine, PlayerUBStateMachine UBStateMachine) : base(LBstateMachine, UBStateMachine)
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
        base.Update();
        if(LBStateMachine.MovementInput != Vector2.zero)
        {
            LBStateMachine.ChangeState(LBStateMachine.lb_WalkState);
        }
    }
}
