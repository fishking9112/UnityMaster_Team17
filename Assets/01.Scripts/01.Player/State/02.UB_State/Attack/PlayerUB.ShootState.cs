using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUB_ShootState : PlayerUB_AttackState
{
    public PlayerUB_ShootState(PlayerLBStateMachine LBstateMachine, PlayerUBStateMachine UBStateMachine) : base(LBstateMachine, UBStateMachine)
    {
    }
}
