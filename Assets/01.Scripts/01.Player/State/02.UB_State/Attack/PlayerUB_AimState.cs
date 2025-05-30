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

        StartAnimation(LBStateMachine.player.AnimationData.UB_AimParameterHash);
    }

    public override void Exit()
    {
        base.Exit();

        StopAnimation(LBStateMachine.player.AnimationData.UB_AimParameterHash);
    }

    public override void Update()
    {
        base.Update();
        if (!UBStateMachine.player.Input.playerActions.Aim.IsPressed())
        {
            UBStateMachine.ChangeState(UBStateMachine.ub_ArmedState);
        }
    }

    protected override void AddInputActionCallbacks()
    {
        base.AddInputActionCallbacks();

        UBStateMachine.player.Input.playerActions.Shoot.started += OnShoot;
        UBStateMachine.player.Input.playerActions.Grenade.started += OnGrenade;

    }

    protected override void RemoveInputActionCallbacks()
    {
        base.RemoveInputActionCallbacks();

        UBStateMachine.player.Input.playerActions.Shoot.started -= OnShoot;
        UBStateMachine.player.Input.playerActions.Grenade.started -= OnGrenade;
    }

    private void OnShoot(InputAction.CallbackContext context)
    {
        UBStateMachine.ub_ShootState.interTransition = true;
        interTransition = true;
        UBStateMachine.ChangeState(UBStateMachine.ub_ShootState);
    }

    private void OnGrenade(InputAction.CallbackContext context)
    {
        UBStateMachine.ub_GrenadeState.interTransition = true;
        interTransition = true;
        UBStateMachine.ChangeState(UBStateMachine.ub_GrenadeState);
    }
}
