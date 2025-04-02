using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerUB_GrenadeState : PlayerUB_AttackState
{
    Coroutine shootCoroutine;
    public float fireAnimationModifier;

    bool wasShot;

    public PlayerUB_GrenadeState(PlayerLBStateMachine LBstateMachine, PlayerUBStateMachine UBStateMachine) : base(LBstateMachine, UBStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

        wasShot = false;
        StartAnimation(LBStateMachine.player.AnimationData.UB_GrenadeParameterHash);
    }

    public override void Exit()
    {
        base.Exit();

        StopAnimation(LBStateMachine.player.AnimationData.UB_GrenadeParameterHash);
    }


    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        AnimatorStateInfo current = LBStateMachine.player.Animator.GetCurrentAnimatorStateInfo(2);
        AnimatorStateInfo next = LBStateMachine.player.Animator.GetNextAnimatorStateInfo(2);

        if (!wasShot)
        {
            if (current.IsTag("Grenade") && current.normalizedTime >= 1f / 3f) // 애니메이션 1/3 지점에서 유탄 발사
            {
                wasShot = true;
                //유탄 발사
                LBStateMachine.player.playerUseItem.ShootRocket();
            }
            else if (next.IsTag("Grenade") && next.normalizedTime >= 1f / 3f)
            {
                wasShot = true;
                //유탄 발사
                LBStateMachine.player.playerUseItem.ShootRocket();
            }
        }
        else
        {
            if (current.IsTag("Grenade") && current.normalizedTime >= 0.95f) // 애니메이션 1/3 지점에서 유탄 발사
            {
                UBStateMachine.ub_AimState.interTransition = true;
                interTransition = true;
                UBStateMachine.ChangeState(UBStateMachine.ub_AimState);
            }
            else if (next.IsTag("Grenade") && next.normalizedTime >= 0.95f)
            {
                UBStateMachine.ub_AimState.interTransition = true;
                interTransition = true;
                UBStateMachine.ChangeState(UBStateMachine.ub_AimState);
            }
        }
    }
}
