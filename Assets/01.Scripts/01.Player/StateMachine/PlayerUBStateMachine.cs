public class PlayerUBStateMachine : PlayerStateMachine
{
    protected IState currentState; // IState 클래스를 넣을 칸(카세트 오디오를 넣을 공간)

    protected Player player;
    protected PlayerLBStateMachine LBStateMachine;
    public PlayerUBStateMachine(Player player) : base(player)
    {
    }

    public void Initialize(PlayerLBStateMachine LBStateMachine)
    {
        this.LBStateMachine = LBStateMachine;

    }
}