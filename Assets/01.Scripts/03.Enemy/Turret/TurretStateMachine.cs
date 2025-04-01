using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretStateMachine : StateMachine
{
    public Turret Turret { get; }

    public TurretIdleState IdleState { get; set; }
    public TurretAttackState AttackState { get; set; }
    public TurretDeadState DeadState { get; set; }

    public TurretStateMachine(Turret turret)
    {
        Turret = turret;

        IdleState = new TurretIdleState(this);
        AttackState = new TurretAttackState(this);
        DeadState = new TurretDeadState(this);
    }
}
