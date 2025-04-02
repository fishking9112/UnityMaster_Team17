using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUB_ReloadState : PlayerUB_BaseState
{
    public PlayerUB_ReloadState(PlayerLBStateMachine LBstateMachine, PlayerUBStateMachine UBStateMachine) : base(LBstateMachine, UBStateMachine)
    {
    }
    public override void Enter()
    {
        base.Enter();
        StartAnimation(LBStateMachine.player.AnimationData.UB_ReloadParameterHash); 
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(LBStateMachine.player.AnimationData.UB_ReloadParameterHash);
    }

    public override void Update()
    {
        base.Update();
        if (CheckReloadComplete())
        {
            UBStateMachine.ChangeState(UBStateMachine.ub_ArmedState);
        }
    }

    private bool CheckReloadComplete()
    {
        AnimatorStateInfo current = UBStateMachine.player.Animator.GetCurrentAnimatorStateInfo(2);
        AnimatorStateInfo next = UBStateMachine.player.Animator.GetCurrentAnimatorStateInfo(2);

        if (current.IsTag("Reload") && current.normalizedTime > 0.95f)
        {
            return true;
        }
        else if (next.IsTag("Reload") && next.normalizedTime > 0.95f)
        {
            return true;
        }
        return false;
    }
}
