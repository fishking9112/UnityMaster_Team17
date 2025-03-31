using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLB_BaseState : Player_BaseState
{

    public PlayerLB_BaseState(PlayerLBStateMachine LBstateMachine, PlayerUBStateMachine UBStateMachine) : base(LBstateMachine, UBStateMachine)
    {
    }

    public override void Update()
    {
        base.Update();
        LBStateMachine.player.Animator.SetFloat("MoveSpeed", LBStateMachine.MovementSpeedModifier * animationSpeedModifier); // 테스트용
    }
}
