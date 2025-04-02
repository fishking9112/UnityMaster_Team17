using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLB_GroundedState : PlayerLB_BaseState
{
    public PlayerLB_GroundedState(PlayerLBStateMachine LBstateMachine, PlayerUBStateMachine UBStateMachine) : base(LBstateMachine, UBStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(LBStateMachine.player.AnimationData.LB_GroundedParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(LBStateMachine.player.AnimationData.LB_GroundedParameterHash);
    }

    float Falling;

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        if (!LBStateMachine.player.Controller.isGrounded) // 내리막길에서 추락모션 안나오게
        {
            Falling += Time.fixedDeltaTime;
            if (Falling > 0.2)
            {
                LBStateMachine.ChangeState(LBStateMachine.lb_FallState);
            }
        }
        else
        {
            Falling = 0;
        }
    }

    protected override void AddInputActionCallbacks()
    {
        base.AddInputActionCallbacks();

        LBStateMachine.player.Input.playerActions.Movement.canceled += OnMovementCanceled;
        LBStateMachine.player.Input.playerActions.Jump.started += OnJumpStarted;

    }

    protected override void RemoveInputActionCallbacks()
    {
        base.RemoveInputActionCallbacks();

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

        LBStateMachine.ChangeState(LBStateMachine.lb_JumpState);
    }

    //protected void OnSwitchingWalkMode(InputAction.CallbackContext context)
    //{
    //    WalkMode = !WalkMode;
    //}
}
