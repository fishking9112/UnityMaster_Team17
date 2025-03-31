using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerUB_AimState : PlayerUB_AttackState
{
    public PlayerUB_AimState(PlayerLBStateMachine LBstateMachine, PlayerUBStateMachine UBStateMachine) : base(LBstateMachine, UBStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

        UBStateMachine.player.VirtualCamera.Priority = 20;
        StartAnimation(LBStateMachine.player.AnimationData.LB_WalkParameterHash); // 수정해야함
    }

    public override void Exit()
    {
        base.Exit();

        UBStateMachine.player.VirtualCamera.Priority = 0;
        StopAnimation(LBStateMachine.player.AnimationData.LB_WalkParameterHash);
    }

    protected override void AddInputActionCallbacks()
    {
        base.AddInputActionCallbacks();

        UBStateMachine.player.Input.playerActions.Aim.canceled += OnAimCanceled;
    }

    protected override void RemoveInputActionCallbacks()
    {
        base.RemoveInputActionCallbacks();

        UBStateMachine.player.Input.playerActions.Aim.canceled += OnAimCanceled;
    }

    private void OnAimCanceled(InputAction.CallbackContext context)
    {

    }
}
