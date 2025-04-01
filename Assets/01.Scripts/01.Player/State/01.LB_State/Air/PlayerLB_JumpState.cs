public class PlayerLB_JumpState : PlayerLB_AirState
{
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
        if (LBStateMachine.player.Animator.GetNextAnimatorStateInfo(1).normalizedTime >= 1) // 랜딩 애니메이션이 전부 재생되면 idle로 전환
        {
            LBStateMachine.ChangeState(LBStateMachine.lb_AscendState);
        }
    }
}