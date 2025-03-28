using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    protected IState currentState; // IState 클래스를 넣을 칸(카세트 오디오를 넣을 공간)

    public Player player;

    public Vector2 MovementInput { get; set; }

    public PlayerStateMachine(Player player)
    {
        this.player = player;
    }

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