using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLB_WalkState : PlayerLB_GroundedState
{
    int x;
    int y;
    public float walkSpeed;
    public PlayerLB_WalkState(PlayerLBStateMachine LBstateMachine, PlayerUBStateMachine UBStateMachine) : base(LBstateMachine, UBStateMachine)
    {
        x = LBStateMachine.player.AnimationData.LB_XParameterHash;
        y = LBStateMachine.player.AnimationData.LB_YParameterHash;
        walkSpeed = LBStateMachine.player.playerSO.GroundData.WalkSpeed;
    }

    public override void Enter()
    {
        LBStateMachine.MovementSpeedModifier = walkSpeed;
        animationSpeedModifier = 4f;
        //Debug.Log($"Enter:{animationSpeedModifier}");
        base.Enter();
        StartAnimation(LBStateMachine.player.AnimationData.LB_WalkParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(LBStateMachine.player.AnimationData.LB_WalkParameterHash);
    }

    public override void Update()
    {
        base.Update();

        if (UBStateMachine.AttackMode)
        {
            animationSpeedModifier = 3f;
            LBStateMachine.player.Animator.SetFloat(x, LBStateMachine.MovementInput.x);
            LBStateMachine.player.Animator.SetFloat(y, LBStateMachine.MovementInput.y);
        }
        else
        {
            LBStateMachine.player.Animator.SetFloat(x, 0);
            if (LBStateMachine.RunMode)
            {
                LBStateMachine.player.Animator.SetFloat(y, 2);
            }
            else
            {
                LBStateMachine.player.Animator.SetFloat(y, 1);
            }
        }
    }
}
