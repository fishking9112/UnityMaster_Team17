public class PlayerUBStateMachine : PlayerStateMachine
{
    protected PlayerLBStateMachine LBStateMachine;

    public PlayerUB_UnArmedState ub_UnArmedState;

    public PlayerUBStateMachine(Player player) : base(player)
    {
    }

    public void Initialize(PlayerLBStateMachine LBStateMachine)
    {
        this.LBStateMachine = LBStateMachine;

        ub_UnArmedState = new PlayerUB_UnArmedState(LBStateMachine, this);
    }
}