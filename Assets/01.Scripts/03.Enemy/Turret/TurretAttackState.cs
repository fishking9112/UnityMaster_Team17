using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAttackState : TurretBaseState
{
    private float lastattacktime;

    public TurretAttackState(TurretStateMachine stateMachine) : base(stateMachine)
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

        //플레이어를 바라볼 수 있도록
        Transform playerTransform = stateMachine.Turret.TurnHeadPosition.transform;
        Quaternion targetRotation = Quaternion.LookRotation((GameManager.Instance.player.transform.position - stateMachine.Turret.TurnHeadPosition.transform.position).normalized);
        playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, targetRotation, 2f * Time.deltaTime);
       
        //공속에 따른 발사
        if (Time.time - lastattacktime >= 1 / stateMachine.Turret.AttackRate)
        {
            lastattacktime = Time.time;
            stateMachine.Turret.ShootRiffle();
        }

        if (!IsPlayerInSight() || (IsInChasingDistance() > stateMachine.Turret.ChasingMaxRange))
        {
            stateMachine.ChangeState(stateMachine.IdleState);
        }
    }
}
