using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeadState : BossBaseState
{
    public BossDeadState(BossStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

        TriggerAnimation(stateMachine.Boss.AnimationData.IsDeadParameterHash);

        foreach(Collider collider in stateMachine.Boss.Partscollider)
        {
            collider.enabled = false;
        }
    }
}
