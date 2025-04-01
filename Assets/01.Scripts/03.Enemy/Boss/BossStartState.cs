using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStartState : BossBaseState
{
    private bool StartMode = false;
    private float StartTime = 0;
    public BossStartState(BossStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if(IsInChasingDistance() <= stateMachine.Boss.Data.PlayerChasingRange)
        {
            StartAnimation(stateMachine.Boss.AnimationData.IsOnParameterHash);
            StartMode = true;
        }

        if (StartMode)
        {
            StartTime += Time.deltaTime;

            if (StartTime > 2)
            {
                stateMachine.ChangeState(stateMachine.IdleState);
            }
        }
    }
}
