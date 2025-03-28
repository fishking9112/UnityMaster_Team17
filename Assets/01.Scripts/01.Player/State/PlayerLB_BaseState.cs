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
        Debug.Log($"Move하는 상태 이름:{name}");
    }
}
