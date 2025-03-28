using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseState : IState
{
    protected EnemyStateMachine stateMachine;
    private float lastCheckTime = 0;

    public EnemyBaseState(EnemyStateMachine stateMachine)
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
    protected void StartAnimation(int animatorHash)
    {
        stateMachine.Enemy.animator.SetBool(animatorHash, true);
    }

    protected void StopAnimation(int animatorHash)
    {
        stateMachine.Enemy.animator.SetBool(animatorHash, false);
    }

    protected float IsInChasingRange()
    {
        Vector3 directionToPlayer = stateMachine.Player.transform.position - stateMachine.Enemy.transform.position;
        float playerDistanceSqr = directionToPlayer.sqrMagnitude;
        if(playerDistanceSqr <= stateMachine.Enemy.Data.PlayerChasingRange)
        {
            float angle = Vector3.Angle(stateMachine.Enemy.transform.forward, directionToPlayer);
            if(angle <= stateMachine.Enemy.Data.EnemySightAngle)
            {
                return playerDistanceSqr;
            }
        }
        return -1;
    }

    protected float IsInChasingDistance()
    {
        return (stateMachine.Player.transform.position - stateMachine.Enemy.transform.position).sqrMagnitude;
    }

    protected bool IsPlayerInSight()
    {
        Ray[] ray = new Ray[9]
        {
                new Ray(stateMachine.Enemy.EnemyRayPosition.transform.position, (stateMachine.Player.transform.position + new Vector3(0,1,0)) - stateMachine.Enemy.EnemyRayPosition.transform.position),
                new Ray(stateMachine.Enemy.EnemyRayPosition.transform.position, (stateMachine.Player.transform.position + new Vector3(0.3f,1,0)) - stateMachine.Enemy.EnemyRayPosition.transform.position),
                new Ray(stateMachine.Enemy.EnemyRayPosition.transform.position, (stateMachine.Player.transform.position + new Vector3(-0.3f,1,0)) - stateMachine.Enemy.EnemyRayPosition.transform.position),
                new Ray(stateMachine.Enemy.EnemyRayPosition.transform.position, (stateMachine.Player.transform.position + new Vector3(0,1.3f,0)) - stateMachine.Enemy.EnemyRayPosition.transform.position),
                new Ray(stateMachine.Enemy.EnemyRayPosition.transform.position, (stateMachine.Player.transform.position + new Vector3(0,0.7f,0)) - stateMachine.Enemy.EnemyRayPosition.transform.position),
                new Ray(stateMachine.Enemy.EnemyRayPosition.transform.position, (stateMachine.Player.transform.position + new Vector3(0.3f,1.3f,0)) - stateMachine.Enemy.EnemyRayPosition.transform.position),
                new Ray(stateMachine.Enemy.EnemyRayPosition.transform.position, (stateMachine.Player.transform.position + new Vector3(0.3f,0.7f,0)) - stateMachine.Enemy.EnemyRayPosition.transform.position),
                new Ray(stateMachine.Enemy.EnemyRayPosition.transform.position, (stateMachine.Player.transform.position + new Vector3(-0.3f,1.3f,0)) - stateMachine.Enemy.EnemyRayPosition.transform.position),
                new Ray(stateMachine.Enemy.EnemyRayPosition.transform.position, (stateMachine.Player.transform.position + new Vector3(-0.3f,0.7f,0)) - stateMachine.Enemy.EnemyRayPosition.transform.position)
        };
        RaycastHit hit;

        for (int i = 0; i < ray.Length; i++)
        {
            if (Physics.Raycast(ray[i], out hit, stateMachine.Enemy.Data.PlayerChasingRange))
            {
                if (hit.collider.gameObject == stateMachine.Player)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
