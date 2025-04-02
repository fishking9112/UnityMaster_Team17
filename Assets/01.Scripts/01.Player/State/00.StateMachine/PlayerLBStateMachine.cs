using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class PlayerLBStateMachine : PlayerStateMachine
{
    private PlayerUBStateMachine UBStateMachine;

    public PlayerLB_GroundedState lb_GroundedState;
    public PlayerLB_IdleState lb_IdleState;
    public PlayerLB_WalkState lb_WalkState;
    public PlayerLB_RunState lb_RunState;

    public PlayerLB_AirState lb_AirState;
    public PlayerLB_JumpState lb_JumpState;
    public PlayerLB_FallState lb_FallState;
    public PlayerLB_LandingState lb_LandingState;
    public PlayerLB_AscendState lb_AscendState;

    public PlayerLB_DashState lb_DashState;

    public float MovementSpeed { get; private set; }
    public float MovementSpeedModifier { get; set; } = 1f;
    public float MovementSpeedModifier2 { get; set; } = 1f;

    public bool movable = true;
    public bool RunMode = false;
    public PlayerLBStateMachine(Player player) : base(player)
    {
    }

    public void Initialize(PlayerUBStateMachine UBStateMachine)
    {
        this.UBStateMachine = UBStateMachine;   

        lb_GroundedState = new PlayerLB_GroundedState(this, UBStateMachine);
        lb_IdleState = new PlayerLB_IdleState(this, UBStateMachine);
        lb_WalkState = new PlayerLB_WalkState(this, UBStateMachine);   
        lb_RunState = new PlayerLB_RunState(this, UBStateMachine);   

        lb_AirState = new PlayerLB_AirState(this, UBStateMachine);
        lb_JumpState = new PlayerLB_JumpState(this, UBStateMachine);
        lb_FallState = new PlayerLB_FallState(this, UBStateMachine);
        lb_LandingState = new PlayerLB_LandingState(this, UBStateMachine);
        lb_AscendState = new PlayerLB_AscendState(this, UBStateMachine);

        lb_DashState = new PlayerLB_DashState(this, UBStateMachine);

        MovementSpeed = player.playerSO.GroundData.BaseSpeed;
    }
}