using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : StateMachine
{
    public Enemy Enemy { get; }
    public float MovementSpeed { get; private set; }
    public float RotationDamping { get; private set; }
    public float MovementSpeedModifier { get; set; } = 1.0f;

    public GameObject Player { get; set; }
    public EnemyIdleState IdleState { get; }
    public EnemyChaseState ChaseState { get; }
    public EnemyAttackState AttackState { get; }

    public EnemyStateMachine(Enemy enemy, GameObject _player)
    {
        Enemy = enemy;
        Player = _player;

        IdleState = new EnemyIdleState(this);
        ChaseState = new EnemyChaseState(this);
        AttackState = new EnemyAttackState(this);

        MovementSpeed = Enemy.Data.NormalSpeed;
        RotationDamping = Enemy.Data.RotationDamping;
    }
}
