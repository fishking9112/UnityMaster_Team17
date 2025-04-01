using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerUB_ShootState : PlayerUB_AttackState
{
    Coroutine shootCoroutine;
    public PlayerUB_ShootState(PlayerLBStateMachine LBstateMachine, PlayerUBStateMachine UBStateMachine) : base(LBstateMachine, UBStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        shootCoroutine = UBStateMachine.player.StartCoroutine(OnShoot(UBStateMachine.player.playerSO.ShootInterval));

        StartAnimation(LBStateMachine.player.AnimationData.UB_ShootParameterHash); // 수정해야함
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

        if (!UBStateMachine.player.Input.playerActions.Shoot.IsPressed())
        {
            UBStateMachine.ChangeState(UBStateMachine.ub_AimState);
        }
    }



    private IEnumerator OnShoot(float interval)
    {
        while (true)
        {
            // 발사 로직
            Debug.Log("발사");

            //인터벌동안 쉬고.
            yield return new WaitForSeconds(interval);
        }
    }
}
