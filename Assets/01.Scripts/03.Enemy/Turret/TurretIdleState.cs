using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretIdleState : TurretBaseState
{
    public TurretIdleState(TurretStateMachine stateMachine) : base(stateMachine)
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

        if(IsInChasingRange() == -1) return;
        else if(IsInChasingRange() <= stateMachine.Turret.ChasingMaxRange)
        {
            if (IsPlayerInSight())
            {
                stateMachine.ChangeState(stateMachine.AttackState);
            }
        }
    }
}
