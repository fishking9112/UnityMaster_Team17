using UnityEngine;
using UnityEngine.InputSystem.XR;

public class PlayerLB_AscendState : PlayerLB_AirState
{
    AnimatorStateInfo current;
    AnimatorStateInfo next;

    public PlayerLB_AscendState(PlayerLBStateMachine LBstateMachine, PlayerUBStateMachine UBStateMachine) : base(LBstateMachine, UBStateMachine)
    {
    }

    public override void Enter()
    {
        LBStateMachine.player.ForceReceiver.jumpStarted = true; // baseState쪽 Update보다 forceReciever쪽 update가 먼저 실행돼서 jump로 vertical 값 수정해도 초기화되는 문제 해결 위해.
        LBStateMachine.player.ForceReceiver.Jump(LBStateMachine.player.playerSO.AirData.JumpForce);

        base.Enter();
        StartAnimation(LBStateMachine.player.AnimationData.LB_AscendParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(LBStateMachine.player.AnimationData.LB_AscendParameterHash);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        current = LBStateMachine.player.Animator.GetCurrentAnimatorStateInfo(1);
        next = LBStateMachine.player.Animator.GetNextAnimatorStateInfo(1);

        // velocity가 음수거나 애니메이션이 전부 실행되면 추락(하강)으로 이동.
        if (LBStateMachine.player.ForceReceiver.Movement.y <= 0) 
        {
            LBStateMachine.ChangeState(LBStateMachine.lb_FallState);
        }
        else if (current.IsTag("Ascend") && current.normalizedTime >= 0.98f) 
        {
            LBStateMachine.ChangeState(LBStateMachine.lb_FallState);
        }
        else if (next.IsTag("Ascend") && next.normalizedTime >= 0.98f)
        {
            LBStateMachine.ChangeState(LBStateMachine.lb_FallState);
        }
    }
}