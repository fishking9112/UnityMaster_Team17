using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUB_BaseState : Player_BaseState
{
    public PlayerUB_BaseState(PlayerLBStateMachine LBstateMachine, PlayerUBStateMachine UBStateMachine) : base(LBstateMachine, UBStateMachine)
    {
    }
}
