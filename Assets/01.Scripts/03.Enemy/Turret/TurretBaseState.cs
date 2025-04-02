using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBaseState : IState
{
    protected TurretStateMachine stateMachine;

    public TurretBaseState(TurretStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    public virtual void Enter()
    {
    }

    public virtual void Exit()
    {
    }

    public virtual void HandleInput()
    {
    }

    public virtual void PhysicsUpdate()
    {
    }

    public virtual void Update()
    {
    }

    public virtual void LateUpdate()
    {
    }

    protected float IsInChasingRange()
    {
        //일정 각도 내에 있는 플레이어와 적의 거리 값, 없으면 -1
        Vector3 directionToPlayer = GameManager.Instance.player.transform.position - stateMachine.Turret.transform.position;
        float playerDistanceSqr = directionToPlayer.sqrMagnitude;
        if (playerDistanceSqr <= stateMachine.Turret.ChasingMaxRange)
        {
            float angle = Vector3.Angle(stateMachine.Turret.transform.forward, directionToPlayer);
            if (angle <= stateMachine.Turret.SeightAngle)
            {
                return playerDistanceSqr;
            }
        }
        return -1;
    }

    protected float IsInChasingDistance()
    {
        //플레이어와 적의 거리 값
        return (GameManager.Instance.player.transform.position - stateMachine.Turret.transform.position).sqrMagnitude;
    }

    protected bool IsPlayerInSight()
    {
        //플레이어 기준으로 9개의 Ray를 통한 플레이어가 시야 내인지 판단하는 코드
        Ray[] ray = new Ray[9]
        {
                new Ray(stateMachine.Turret.TurretShootPosition.transform.position, (GameManager.Instance.player.transform.position + new Vector3(0,1,0)) - stateMachine.Turret.TurretShootPosition.transform.position),
                new Ray(stateMachine.Turret.TurretShootPosition.transform.position, (GameManager.Instance.player.transform.position + new Vector3(0.3f,1,0)) - stateMachine.Turret.TurretShootPosition.transform.position),
                new Ray(stateMachine.Turret.TurretShootPosition.transform.position, (GameManager.Instance.player.transform.position + new Vector3(-0.3f,1,0)) - stateMachine.Turret.TurretShootPosition.transform.position),
                new Ray(stateMachine.Turret.TurretShootPosition.transform.position, (GameManager.Instance.player.transform.position + new Vector3(0,1.3f,0)) - stateMachine.Turret.TurretShootPosition.transform.position),
                new Ray(stateMachine.Turret.TurretShootPosition.transform.position, (GameManager.Instance.player.transform.position + new Vector3(0,0.7f,0)) - stateMachine.Turret.TurretShootPosition.transform.position),
                new Ray(stateMachine.Turret.TurretShootPosition.transform.position, (GameManager.Instance.player.transform.position + new Vector3(0.3f,1.3f,0)) - stateMachine.Turret.TurretShootPosition.transform.position),
                new Ray(stateMachine.Turret.TurretShootPosition.transform.position, (GameManager.Instance.player.transform.position + new Vector3(0.3f,0.7f,0)) - stateMachine.Turret.TurretShootPosition.transform.position),
                new Ray(stateMachine.Turret.TurretShootPosition.transform.position, (GameManager.Instance.player.transform.position + new Vector3(-0.3f,1.3f,0)) - stateMachine.Turret.TurretShootPosition.transform.position),
                new Ray(stateMachine.Turret.TurretShootPosition.transform.position, (GameManager.Instance.player.transform.position + new Vector3(-0.3f,0.7f,0)) - stateMachine.Turret.TurretShootPosition.transform.position)
        };
        RaycastHit hit;

        for (int i = 0; i < ray.Length; i++)
        {
            if (Physics.Raycast(ray[i], out hit, stateMachine.Turret.ChasingMaxRange))
            {
                if (hit.collider.gameObject.GetComponentInParent<Player>())
                {
                    return true;
                }
            }
        }
        return false;
    }
}
