using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_DieState : Player_BaseState
{
    public Player_DieState(PlayerLBStateMachine LBstateMachine, PlayerUBStateMachine UBStateMachine) : base(LBstateMachine, UBStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(LBStateMachine.player.AnimationData.DieParameterHash);
        StartAnimation(UBStateMachine.player.AnimationData.DieParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(LBStateMachine.player.AnimationData.DieParameterHash);
        StopAnimation(UBStateMachine.player.AnimationData.DieParameterHash);
    }

    protected override void AddInputActionCallbacks()
    {
        base.AddInputActionCallbacks();
    }

    protected override void RemoveInputActionCallbacks()
    {
        base.RemoveInputActionCallbacks();
    }
}
