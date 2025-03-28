using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : StateMachine
{
    public Enemy Enemy { get; }
    public float MovementSpeed { get; private set; }
    public float RotationDamping { get; private set; }
    public float MovementSpeedModifier { get; set; } = 1.0f;

    public GameObject Target { get; private set; }
    public EnemyIdleState IdleState { get;}

    //임시 코드
    public GameObject Player;

    public EnemyStateMachine(Enemy enemy)
    {
        Enemy = enemy;
        Target = Player;

        IdleState = new EnemyIdleState(this);

        MovementSpeed = Enemy.Data.NormalSpeed;
        RotationDamping = Enemy.Data.RotationDamping;
    }
}
