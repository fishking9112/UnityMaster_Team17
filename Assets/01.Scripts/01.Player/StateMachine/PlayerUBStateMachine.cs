public class PlayerUBStateMachine : StateMachine
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