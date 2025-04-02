using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStateMachine : StateMachine
{
    public Boss Boss;

    public BossStartState StartState { get; }
    public BossIdleState IdleState { get; }
    public BossChaseState ChaseState { get; }
    public BossMiliAttackState MiliAttackState { get; }
    public BossAttackState AttackState { get; }
    public BossDeadState DeadState { get; }

    public BossStateMachine(Boss boss)
    {
        Boss = boss;

        StartState = new BossStartState(this);
        IdleState = new BossIdleState(this);
        ChaseState = new BossChaseState(this);
        MiliAttackState = new BossMiliAttackState(this);
        AttackState = new BossAttackState(this);
        DeadState = new BossDeadState(this);
    }
}
