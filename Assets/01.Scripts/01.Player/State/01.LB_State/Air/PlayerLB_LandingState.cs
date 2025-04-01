using UnityEngine;

public class PlayerLB_LandingState : PlayerLB_AirState
{
    //private float fallTime;
    public PlayerLB_LandingState(PlayerLBStateMachine LBstateMachine, PlayerUBStateMachine UBStateMachine) : base(LBstateMachine, UBStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(LBStateMachine.player.AnimationData.LB_LandingParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(LBStateMachine.player.AnimationData.LB_LandingParameterHash);
    }

    public override void Update()
    {
        base.Update();
        //LBStateMachine.player.SetController(LBStateMachine.player.BoundHandler.GetHeightBounds());
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        AnimatorStateInfo current = LBStateMachine.player.Animator.GetCurrentAnimatorStateInfo(1);
        AnimatorStateInfo next = LBStateMachine.player.Animator.GetNextAnimatorStateInfo(1);

        if (current.IsTag("Landing") && current.normalizedTime >= 0.9) // 랜딩 애니메이션이 전부 재생되면 idle로 전환
        { 
            LBStateMachine.ChangeState(LBStateMachine.lb_IdleState);
        }
        else if (next.IsTag("Landing") && next.normalizedTime >= 0.9) // 랜딩 애니메이션이 전부 재생되면 idle로 전환
        {
            LBStateMachine.ChangeState(LBStateMachine.lb_IdleState);
        }
    }
}