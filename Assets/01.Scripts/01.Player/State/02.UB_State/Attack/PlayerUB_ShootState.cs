using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerUB_ShootState : PlayerUB_AttackState
{
    Coroutine shootCoroutine;
    public float fireAnimationModifier;

    public PlayerUB_ShootState(PlayerLBStateMachine LBstateMachine, PlayerUBStateMachine UBStateMachine) : base(LBstateMachine, UBStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        //발사는 코루틴으로
        shootCoroutine = UBStateMachine.player.StartCoroutine(OnShoot(UBStateMachine.player.playerSO.FireRPS));

        // 발사 애니메이션 속도계수 조정
        fireAnimationModifier = UBStateMachine.player.playerSO.FireRPS / 15f; // 15는 애니메이션의 기본 RPS
        UBStateMachine.player.Animator.SetFloat("FireRPS", fireAnimationModifier);

        StartAnimation(LBStateMachine.player.AnimationData.UB_ShootParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        UBStateMachine.player.StopCoroutine(shootCoroutine);

        StopAnimation(LBStateMachine.player.AnimationData.UB_ShootParameterHash);
    }

    public override void Update()
    {
        base.Update();

        // 좌클 놓으면 Aim으로 복귀
        if (!UBStateMachine.player.Input.playerActions.Shoot.IsPressed())
        {
            UBStateMachine.ub_AimState.interTransition = true;
            interTransition = true;
            UBStateMachine.ChangeState(UBStateMachine.ub_AimState);
        }
    }



    private IEnumerator OnShoot(float RPS)
    {
        float interval = 1 / RPS;
        while (true)
        {
            //인터벌동안 쉬고.
            yield return new WaitForSeconds(interval / 2);

            // 발사 로직
            Debug.Log("발사");

            //인터벌동안 쉬고.
            yield return new WaitForSeconds(interval / 2);
        }
    }
}
