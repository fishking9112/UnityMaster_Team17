using UnityEngine;

public class PlayerLB_FallState : PlayerLB_AirState
{
    public PlayerLB_FallState(PlayerLBStateMachine LBstateMachine, PlayerUBStateMachine UBStateMachine) : base(LBstateMachine, UBStateMachine)
    {
    }

    private bool resizing;

    public override void Enter()
    {
        base.Enter();
        StartAnimation(LBStateMachine.player.AnimationData.LB_FallParameterHash);

        LBStateMachine.player.StartControllerSizing(0.2f, 1.95f, 1.7f);
        resizing = false;    
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(LBStateMachine.player.AnimationData.LB_FallParameterHash);
        if (!resizing)
        {
            LBStateMachine.player.StartControllerSizing(0.1f);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        if (LBStateMachine.player.Controller.isGrounded)
        {
            // 추락 시간이 1초 이상이면 Landing으로 전환, 아니면 idle로 전환 
            if (Time.time - fallTime > 0.3f)
            {
                LBStateMachine.ChangeState(LBStateMachine.lb_LandingState);

                LBStateMachine.player.StartControllerSizing(0.4f);
                resizing = true;
            }
            else
            {
                LBStateMachine.ChangeState(LBStateMachine.lb_IdleState);

                LBStateMachine.player.StartControllerSizing(0.3f);
                resizing = true;
            }
        }
    }
}