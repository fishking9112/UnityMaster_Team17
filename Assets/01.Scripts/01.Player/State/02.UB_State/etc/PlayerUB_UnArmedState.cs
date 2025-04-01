using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerUB_UnArmedState : PlayerUB_BaseState
{
    public PlayerUB_UnArmedState(PlayerLBStateMachine LBstateMachine, PlayerUBStateMachine UBStateMachine) : base(LBstateMachine, UBStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(LBStateMachine.player.AnimationData.UB_UnArmedParameterHash); // 수정해야함.
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(LBStateMachine.player.AnimationData.UB_UnArmedParameterHash);
    }

    protected override void AddInputActionCallbacks()
    {
        base.AddInputActionCallbacks();

        UBStateMachine.player.Input.playerActions.Aim.started += OnAimStarted;
        UBStateMachine.player.Input.playerActions.Arm.started += OnArmedStarted;
    }

    protected override void RemoveInputActionCallbacks()
    {
        base.RemoveInputActionCallbacks();

        UBStateMachine.player.Input.playerActions.Aim.started -= OnAimStarted;
        UBStateMachine.player.Input.playerActions.Arm.started -= OnArmedStarted;
    }

    private void OnAimStarted(InputAction.CallbackContext context)
    {
        UBStateMachine.ChangeState(UBStateMachine.ub_AimState);
    }

    private void OnArmedStarted(InputAction.CallbackContext context)
    {
        UBStateMachine.ChangeState(UBStateMachine.ub_ArmedState);
    }
}
