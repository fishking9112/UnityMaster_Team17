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
        StartAnimation(LBStateMachine.player.AnimationData.LB_IdleParameterHash); // 수정해야함.
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(LBStateMachine.player.AnimationData.LB_IdleParameterHash);
    }

    public override void Update()
    {

    }

    protected override void AddInputActionCallbacks()
    {
        base.AddInputActionCallbacks();

        UBStateMachine.player.Input.playerActions.Aim.started += OnAimStarted;
    }

    protected override void RemoveInputActionCallbacks()
    {
        base.RemoveInputActionCallbacks();

        UBStateMachine.player.Input.playerActions.Aim.started -= OnAimStarted;
    }

    private void OnAimStarted(InputAction.CallbackContext context)
    {
        UBStateMachine.ChangeState(UBStateMachine.ub_AimState);
    }
}
