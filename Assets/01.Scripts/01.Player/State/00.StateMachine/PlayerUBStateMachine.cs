public class PlayerUBStateMachine : PlayerStateMachine
{
    protected PlayerLBStateMachine LBStateMachine;

    public PlayerUB_UnArmedState ub_UnArmedState;
    public PlayerUB_ArmedState ub_ArmedState;
    public PlayerUB_AimState ub_AimState;
    public PlayerUB_ShootState ub_ShootState;
    public PlayerUB_ReloadState ub_ReloadState;

    public PlayerUBStateMachine(Player player) : base(player)
    {
    }

    public void Initialize(PlayerLBStateMachine LBStateMachine)
    {
        this.LBStateMachine = LBStateMachine;

        ub_UnArmedState = new PlayerUB_UnArmedState(LBStateMachine, this);
        ub_ArmedState = new PlayerUB_ArmedState(LBStateMachine, this);
        ub_AimState = new PlayerUB_AimState(LBStateMachine, this);
        ub_ShootState = new PlayerUB_ShootState(LBStateMachine, this);
        ub_ReloadState = new PlayerUB_ReloadState(LBStateMachine, this);
    }
}