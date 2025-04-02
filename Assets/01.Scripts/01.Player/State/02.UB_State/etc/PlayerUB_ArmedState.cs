using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerUB_ArmedState : PlayerUB_BaseState
{
    public PlayerUB_ArmedState(PlayerLBStateMachine LBstateMachine, PlayerUBStateMachine UBStateMachine) : base(LBstateMachine, UBStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(LBStateMachine.player.AnimationData.UB_ArmedParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(LBStateMachine.player.AnimationData.UB_ArmedParameterHash);
    }

    protected override void AddInputActionCallbacks()
    {
        base.AddInputActionCallbacks();

        UBStateMachine.player.Input.playerActions.Aim.started += OnAimStarted;
        UBStateMachine.player.Input.playerActions.Arm.started += OnUnArmedStarted;
        UBStateMachine.player.Input.playerActions.Reload.started += OnReloadStarted;
    }

    protected override void RemoveInputActionCallbacks()
    {
        base.RemoveInputActionCallbacks();

        UBStateMachine.player.Input.playerActions.Aim.started -= OnAimStarted;
        UBStateMachine.player.Input.playerActions.Arm.started -= OnUnArmedStarted;
        UBStateMachine.player.Input.playerActions.Reload.started -= OnReloadStarted;
    }

    private void OnAimStarted(InputAction.CallbackContext context)
    {
        UBStateMachine.ChangeState(UBStateMachine.ub_AimState);
    }

    private void OnUnArmedStarted(InputAction.CallbackContext context)
    {
        UBStateMachine.ChangeState(UBStateMachine.ub_UnArmedState);
    }

    private void OnReloadStarted(InputAction.CallbackContext context)
    {
        UBStateMachine.ChangeState(UBStateMachine.ub_ReloadState);
    }
}
