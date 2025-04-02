using UnityEngine;

public class PlayerLB_JumpState : PlayerLB_AirState
{
    AnimatorStateInfo current;
    AnimatorStateInfo next;

    public PlayerLB_JumpState(PlayerLBStateMachine LBstateMachine, PlayerUBStateMachine UBStateMachine) : base(LBstateMachine, UBStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(LBStateMachine.player.AnimationData.LB_JumpParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(LBStateMachine.player.AnimationData.LB_JumpParameterHash);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        current = LBStateMachine.player.Animator.GetCurrentAnimatorStateInfo(1);
        next = LBStateMachine.player.Animator.GetNextAnimatorStateInfo(1);

        if (current.IsTag("Begin") && current.normalizedTime >= 0.95f) // 비긴 애니메이션이 전부 실행되면 상승으로 이동.
        {
            LBStateMachine.ChangeState(LBStateMachine.lb_AscendState);
        }
        else if (next.IsTag("Begin") && next.normalizedTime >= 0.95f) 
        { 
            LBStateMachine.ChangeState(LBStateMachine.lb_AscendState);
        }
    }
}