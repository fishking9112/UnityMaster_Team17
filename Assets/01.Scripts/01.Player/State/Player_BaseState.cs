using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_BaseState : IState
{
    protected PlayerLBStateMachine LBStateMachine;
    protected PlayerUBStateMachine UBStateMachine;

    Camera cam = Camera.main;

    protected float animationSpeedModifier = 1f;
    public bool WalkMode;

    protected Vector3 movementDirection;
    protected float bonusSpeed;

    public Player_BaseState(PlayerLBStateMachine LBStateMachine, PlayerUBStateMachine UBStateMachine)
    {
        this.LBStateMachine = LBStateMachine;
        this.UBStateMachine = UBStateMachine;
    }

    protected virtual void AddInputActionCallbacks()
    {

    }

    protected virtual void RemoveInputActionCallbacks()
    {
    }


    public virtual void Enter()
    {
        AddInputActionCallbacks();
    }

    public virtual void Exit()
    {
        RemoveInputActionCallbacks();
    }

    public virtual void HandleInput()
    {
        ReadMovementInput();
    }

    public virtual void PhysicsUpdate()
    {

    }

    public virtual void Update()
    {
        Move();
    }

    public virtual void LateUpdate()
    {
    }

    protected void StartAnimation(int animationHash)
    {
        LBStateMachine.player.Animator.SetBool(animationHash, true);
    }

    protected void StopAnimation(int animationHash)
    {
        LBStateMachine.player.Animator.SetBool(animationHash, false);
    }

    public void ReadMovementInput()
    {
        LBStateMachine.MovementInput = LBStateMachine.player.Input.playerActions.Movement.ReadValue<Vector2>();
    }

    private void Move()
    {
        movementDirection = GetMovementDirection();

        Move(movementDirection);

        Rotate(movementDirection);
    }

    private Vector3 GetMovementDirection()
    {

        Vector3 foward = cam.transform.forward;
        Vector3 right = cam.transform.right;

        foward.y = 0;
        right.y = 0;

        foward.Normalize();
        right.Normalize();

        return foward * LBStateMachine.MovementInput.y + right * LBStateMachine.MovementInput.x;
    }

    private void Move(Vector3 direction)
    {
        Vector3 movement = ((direction * (GetMovementSpeed() + bonusSpeed)) + LBStateMachine.player.ForceReceiver.Movement) * Time.deltaTime; // + verticalMovement
        LBStateMachine.player.Controller.Move(movement);
    }

    private float GetMovementSpeed()
    {
        float moveSpeed = LBStateMachine.MovementSpeed * LBStateMachine.MovementSpeedModifier * LBStateMachine.MovementSpeedModifier2; // 베이스 스피드 * 상태 스피드 계수
        return moveSpeed;
    }

    private void Rotate(Vector3 direction)
    {
        if (!UBStateMachine.AttackMode)
        {
            if (direction != Vector3.zero)
            {
                Transform player = LBStateMachine.player.transform;
                Quaternion target = Quaternion.LookRotation(direction);

                player.rotation = Quaternion.Slerp(player.rotation, target, LBStateMachine.player.playerSO.GroundData.RotationDamping * Time.deltaTime);
            }
        }
        //else
        //{
        //    LBStateMachine.player.transform.rotation = Quaternion.LookRotation(UBStateMachine.player.AimVCam.transform.forward);
        //}
    }

    protected virtual void OnMovementCanceled(InputAction.CallbackContext context)
    {
    }

    protected virtual void OnJumpStarted(InputAction.CallbackContext context)
    {
    }


    //protected virtual void OnMovementStarted(InputAction.CallbackContext context) // 이거 안한 이유 = 입력있을때마다 changestate하는 문제.
    //{
    //}

}
