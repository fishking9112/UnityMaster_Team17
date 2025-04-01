using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretDeadState : TurretBaseState
{
    public TurretDeadState(TurretStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        foreach(Collider col in stateMachine.Turret.Partscollider)
        {
            col.isTrigger = false;
        }

        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }
}
