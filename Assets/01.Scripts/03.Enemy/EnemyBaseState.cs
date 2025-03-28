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

    public void Enter()
    {
    }

    public void Exit()
    {
    }

    public void HandleInput()
    {
    }

    public void PhysicsUpdate()
    {
    }

    public void Update()
    {
        Move();
    }
    protected void StartAnimation(int animatorHash)
    {
        stateMachine.Enemy.animator.SetBool(animatorHash, true);
    }

    protected void StopAnimation(int animatorHash)
    {
        stateMachine.Enemy.animator.SetBool(animatorHash, false);
    }

    private void Move()
    {
        Vector3 movementDirection = GetMovementDirection();

        Move(movementDirection);

        Rotate(movementDirection);
    }
    private Vector3 GetMovementDirection()
    {
        Vector3 dir = (stateMachine.Target.transform.position - stateMachine.Enemy.transform.position).normalized;
        return dir;
    }
    private void Move(Vector3 direction)
    {
        float movementSpeed = GetMovementSpeed();
        stateMachine.Enemy.Controller.Move(((direction * movementSpeed) + stateMachine.Enemy.ForceReceiver.Movement) * Time.deltaTime);
    }
    private float GetMovementSpeed()
    {
        float moveSpeed = stateMachine.MovementSpeed * stateMachine.MovementSpeedModifier;
        return moveSpeed;
    }
    private void Rotate(Vector3 direction)
    {
        if (direction != Vector3.zero)
        {
            Transform playerTransform = stateMachine.Enemy.transform;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, targetRotation, stateMachine.RotationDamping * Time.deltaTime);
        }
    }
    protected float IsInChasingRange()
    {
        Vector3 directionToPlayer = stateMachine.Target.transform.position - stateMachine.Enemy.transform.position;
        float angle = Vector3.Angle(stateMachine.Enemy.transform.forward, directionToPlayer);

        return angle / 2;
    }

    protected bool IsPlayerInSight()
    {
        if (Time.time - lastCheckTime > 0.1f)
        {
            lastCheckTime = Time.time;

            Ray ray = new Ray(stateMachine.Enemy.EnemyRayPosition.transform.position, stateMachine.Target.transform.position - stateMachine.Enemy.EnemyRayPosition.transform.position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, stateMachine.Enemy.Data.PlayerChasingRange))
            {
                if (hit.collider.gameObject == stateMachine.Target)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
