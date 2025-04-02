using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLB_DashState : PlayerLB_BaseState
{
    public PlayerLB_DashState(PlayerLBStateMachine LBstateMachine, PlayerUBStateMachine UBStateMachine) : base(LBstateMachine, UBStateMachine)
    {
    }

    float peakDashSpeed;
    Coroutine DashCoroutine;

    public override void Enter()
    {
        base.Enter();
        StartAnimation(LBStateMachine.player.AnimationData.LB_DashParameterHash);
        peakDashSpeed = LBStateMachine.player.playerSO.DashSpeed;
        StartDash();
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(LBStateMachine.player.AnimationData.LB_DashParameterHash);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        //AfterDash();
    }

    protected void StartDash()
    {
        if (DashCoroutine != null)
        {
            LBStateMachine.player.StopCoroutine(DashCoroutine);
        }
        DashCoroutine = LBStateMachine.player.StartCoroutine(Dash()); // 코루틴 실행을 위해 아무 모노비해비어 가져옴.
    }

    IEnumerator Dash() // 속도 증가 대쉬.
    {
        float accelerationDuration = 0.2f;
        float elapsedTime = 0;

        while (elapsedTime < accelerationDuration)
        {
            float t = 1f - Mathf.Pow(1f - (elapsedTime / accelerationDuration), 3);
            bonusSpeed = Mathf.Lerp(0, peakDashSpeed, t);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        float decelerationDuration = 0.8f;
        elapsedTime = 0;

        while (elapsedTime < decelerationDuration)
        {
            float t = Mathf.Pow(elapsedTime / decelerationDuration, 3);
            bonusSpeed = Mathf.Lerp(peakDashSpeed, 0f, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        bonusSpeed = 0f;

        LBStateMachine.ChangeState(LBStateMachine.lb_IdleState);
        LBStateMachine.player.boosterEff.SetActive(false);
    }
}
