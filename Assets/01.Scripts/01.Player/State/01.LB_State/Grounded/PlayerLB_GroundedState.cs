using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLB_GroundedState : PlayerLB_BaseState
{
    public PlayerLB_GroundedState(PlayerLBStateMachine LBstateMachine, PlayerUBStateMachine UBStateMachine) : base(LBstateMachine, UBStateMachine)
    {
    }

    protected override void AddInputActionCallbacks()
    {
        LBStateMachine.player.Input.playerActions.Movement.canceled += OnMovementCanceled;

        LBStateMachine.player.Input.playerActions.Jump.started += OnJumpStarted;

    }

    protected override void RemoveInputActionCallbacks()
    {
        LBStateMachine.player.Input.playerActions.Movement.canceled -= OnMovementCanceled;

        LBStateMachine.player.Input.playerActions.Jump.started -= OnJumpStarted;
    }

    protected override void OnMovementCanceled(InputAction.CallbackContext context)
    {
        if (LBStateMachine.MovementInput != Vector2.zero)
        {
            LBStateMachine.ChangeState(LBStateMachine.lb_IdleState);
        }

        base.OnMovementCanceled(context);
    }

    protected override void OnJumpStarted(InputAction.CallbackContext context)
    {
        //LBStateMachine.ChangeState(LBStateMachine.jumpStatww)

        base.OnJumpStarted(context);
    }
}
