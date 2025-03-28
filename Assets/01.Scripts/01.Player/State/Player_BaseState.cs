using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_BaseState : IState
{
    protected PlayerLBStateMachine LBstateMachine;
    protected PlayerUBStateMachine UBStateMachine;

    public Player_BaseState(PlayerLBStateMachine LBstateMachine, PlayerUBStateMachine UBStateMachine)
    {
        this.LBstateMachine = LBstateMachine;
        this.UBStateMachine = UBStateMachine;
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

    protected void StartAnimation(int animationHash)
    {

    }

    protected void StopAnimation(int animationHash)
    {

    }

    public void ReadMovementInput()
    {
        LBstateMachine.MovementInput = LBstateMachine.player.Input.playerActions.Movement.ReadValue<Vector2>();
    }
}
