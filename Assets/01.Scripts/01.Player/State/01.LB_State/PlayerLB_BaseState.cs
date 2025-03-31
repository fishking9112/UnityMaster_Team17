using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLB_BaseState : Player_BaseState
{

    public PlayerLB_BaseState(PlayerLBStateMachine LBstateMachine, PlayerUBStateMachine UBStateMachine) : base(LBstateMachine, UBStateMachine)
    {
    }

    public override void Update()
    {
        base.Update();
        //LBStateMachine.player.Animator.SetFloat("MoveSpeed", LBStateMachine.MovementSpeedModifier * animationSpeedModifier); // 테스트용
    }

    protected override void AddInputActionCallbacks()
    {
        base.AddInputActionCallbacks();

        LBStateMachine.player.Input.playerActions.Dash.started += OnDashStarted;
    }

    protected override void RemoveInputActionCallbacks()
    {
        base.RemoveInputActionCallbacks();

        LBStateMachine.player.Input.playerActions.Dash.started -= OnDashStarted;
    }

    protected virtual void OnDashStarted(InputAction.CallbackContext context)
    {
        LBStateMachine.ChangeState(LBStateMachine.lb_DashState);
    }
}
