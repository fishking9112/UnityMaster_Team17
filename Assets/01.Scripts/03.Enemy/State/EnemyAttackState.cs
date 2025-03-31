using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
    private float lastattacktime;

    public EnemyAttackState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }
    public override void Enter()
    {
        stateMachine.MovementSpeedModifier = 1f;
        stateMachine.Enemy.agent.speed = stateMachine.MovementSpeed * stateMachine.MovementSpeedModifier;
        stateMachine.Enemy.agent.stoppingDistance = stateMachine.Enemy.Data.RemainAttackRange;

        base.Enter();
        //공속에 비례한 애니메이션 속도
        stateMachine.Enemy.animator.SetFloat(stateMachine.Enemy.AnimationData.SpeedParameterHash, stateMachine.Enemy.Data.AttackRate);
        StartAnimation(stateMachine.Enemy.AnimationData.ShootParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Enemy.AnimationData.ShootParameterHash);
        stateMachine.Enemy.agent.stoppingDistance = 0;
    }

    public override void Update()
    {
        base.Update();
        
        //플레이어를 바라볼 수 있도록
        Transform playerTransform = stateMachine.Enemy.transform;
        Quaternion targetRotation = Quaternion.LookRotation((stateMachine.Player.transform.position - stateMachine.Enemy.transform.position).normalized);
        playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, targetRotation, stateMachine.RotationDamping * 2 * Time.deltaTime);

        //공속에 따른 발사
        if(Time.time - lastattacktime >= 1 / stateMachine.Enemy.Data.AttackRate)
        {
            lastattacktime = Time.time;
            stateMachine.Enemy.ShootRiffle();
        }

        //시야에 없든가 사격 범위 밖으로 나가면 추적으로
        if (!IsPlayerInSight() || (IsInChasingDistance() > stateMachine.Enemy.Data.RemainAttackRange))
        {
            stateMachine.ChangeState(stateMachine.ChaseState);
        }
    }
}
