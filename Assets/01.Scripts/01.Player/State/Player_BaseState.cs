using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_BaseState : IState
{
    protected PlayerLBStateMachine LBStateMachine;
    protected PlayerUBStateMachine UBStateMachine;

    Camera cam = Camera.main;

    protected float animationSpeedModifier =1f;


    protected string name;

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
        //Debug.Log($"이름:{name},애니메이션:{animationSpeedModifier}");
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
        Vector3 movementDirection = GetMovementDirection();

        Move(movementDirection);

        Rotate(movementDirection);

        LBStateMachine.player.Animator.SetFloat("MoveSpeed", LBStateMachine.MovementSpeedModifier * animationSpeedModifier); // 테스트용
        //Debug.Log($"Move하는 상태 이름:{name}");
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
        Vector3 movement = ((direction * GetMovementSpeed()) + LBStateMachine.player.ForceReceiver.Movement) * Time.deltaTime; // + verticalMovement
        LBStateMachine.player.Controller.Move(movement);
    }

    private float GetMovementSpeed()
    {
        float moveSpeed = LBStateMachine.MovementSpeed * LBStateMachine.MovementSpeedModifier;
        return moveSpeed;
    }

    private void Rotate(Vector3 direction)
    {
        if(direction != Vector3.zero)
        {
            Transform player = LBStateMachine.player.transform;
            Quaternion target = Quaternion.LookRotation(direction);

            player.rotation = Quaternion.Slerp(player.rotation, target, LBStateMachine.player.playerSO.GroundData.RotationDamping * Time.deltaTime); 
        }
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
