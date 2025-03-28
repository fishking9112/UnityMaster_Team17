using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    public Player player;

    public Vector2 MovementInput { get; set; }

    public PlayerStateMachine(Player player)
    {
        this.player = player;
    }
}