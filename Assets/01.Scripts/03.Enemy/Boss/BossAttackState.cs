using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackState : BossBaseState
{
    public BossAttackState(BossStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

        StartAnimation(stateMachine.Boss.AnimationData.AttackParameterHash);

        ShootToPlayer();
    }

    public override void Exit()
    {
        base.Exit();

        StopAnimation(stateMachine.Boss.AnimationData.AttackParameterHash);
    }

    public override void Update()
    {
        base.Update();

        Transform playerTransform = stateMachine.Boss.transform;
        Quaternion targetRotation = Quaternion.LookRotation((GameManager.Instance.player.transform.position - stateMachine.Boss.transform.position).normalized);
        playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, targetRotation, 6 * Time.deltaTime);
    }

    void ShootToPlayer()
    {
        if (stateMachine.Boss.IsRightArm && stateMachine.Boss.LastGunAttack + stateMachine.Boss.GunRate < Time.time)
        {
            stateMachine.Boss.Riffle();
        }
        else
        {
            stateMachine.Boss.Rocket();
        }
    }
}
