using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    public void Enter(); // 메서드 구독/구취 및 애니메이션 파라미터 조작
    public void Exit();// 메서드 구독/구취 및 애니메이션 파라미터 조작
    public void HandleInput();
    public void Update();
    public void PhysicsUpdate();
}

public abstract class StateMachine
{
    protected IState currentState; // IState 클래스를 넣을 칸(카세트 오디오를 넣을 공간)

    public void ChangeState(IState state)
    {
        currentState?.Exit(); 
        currentState = state; // 카세트 오디오 넣기
        currentState?.Enter();
    }

    public void HanldeInput()
    {
        currentState.HandleInput();
    }

    public void Update()
    {
        currentState.Update();
    }

    public void PhysicsUpdate()
    {
        currentState.PhysicsUpdate();
    }
}
