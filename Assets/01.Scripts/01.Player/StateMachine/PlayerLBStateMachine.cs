using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class PlayerLBStateMachine : PlayerStateMachine
{
    private PlayerUBStateMachine UBStateMachine;

    public PlayerLB_GroundedState lb_GroundedState;
    public PlayerLB_IdleState lb_IdleState;
    public PlayerLB_WalkState lb_WalkState;
    public PlayerLB_AirState lb_AirState;

    public float MovementSpeed { get; private set; }
    public float MovementSpeedModifier { get; set; } = 1f;

    public PlayerLBStateMachine(Player player) : base(player)
    {
    }

    public void Initialize(PlayerUBStateMachine UBStateMachine)
    {
        this.UBStateMachine = UBStateMachine;   

        lb_GroundedState = new PlayerLB_GroundedState(this, UBStateMachine);
        lb_IdleState = new PlayerLB_IdleState(this, UBStateMachine);
        lb_WalkState = new PlayerLB_WalkState(this, UBStateMachine);   
        lb_AirState = new PlayerLB_AirState(this, UBStateMachine);

        MovementSpeed = player.playerSO.GroundData.BaseSpeed;
    }
}