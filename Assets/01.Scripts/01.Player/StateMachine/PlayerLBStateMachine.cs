using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class PlayerLBStateMachine : PlayerStateMachine
{
    protected IState currentState; // IState 클래스를 넣을 칸(카세트 오디오를 넣을 공간)

    public Player player;
    private PlayerUBStateMachine UBStateMachine;

    public PlayerLB_GroundedState groundedState;
    public PlayerLB_IdleState idleState;
    public PlayerLB_WalkState walkState;
    public PlayerLB_AirState airState;

    public Vector2 MovementInput { get; set; } 

    public PlayerLBStateMachine(Player player) : base(player)
    {
    }

    public void Initialize(PlayerUBStateMachine UBStateMachine)
    {
        this.UBStateMachine = UBStateMachine;   
        groundedState = new PlayerLB_GroundedState(this, UBStateMachine);
        idleState = new PlayerLB_IdleState(this, UBStateMachine);
        walkState = new PlayerLB_WalkState(this, UBStateMachine);   
        airState = new PlayerLB_AirState(this, UBStateMachine);
    }
}