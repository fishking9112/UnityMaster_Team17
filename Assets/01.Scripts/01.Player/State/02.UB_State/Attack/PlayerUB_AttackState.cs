using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUB_AttackState : PlayerUB_BaseState
{
    public Transform spine;
    CinemachinePOV aimCamPOV;
    //CinemachinePOV naviCamPOV;

    public bool interTransition;

    public PlayerUB_AttackState(PlayerLBStateMachine LBstateMachine, PlayerUBStateMachine UBStateMachine) : base(LBstateMachine, UBStateMachine)
    {
        spine = UBStateMachine.player.Animator.GetBoneTransform(HumanBodyBones.Spine);
        aimCamPOV = UBStateMachine.player.AimVCam.GetCinemachineComponent<CinemachinePOV>();
        //naviCamPOV = UBStateMachine.player.NaviVCam.GetCinemachineComponent<CinemachinePOV>();
    }


    public override void Enter()
    {
        base.Enter();

        //내부 전환이면 건너뜀
        if (interTransition)
        {
            interTransition = false;
            return;
        }

        //플레이어를 카메라 방향으로 회전
        Vector3 flatFwd = Camera.main.transform.forward;
        flatFwd.y = 0;
        Quaternion fwd = Quaternion.LookRotation(flatFwd);
        UBStateMachine.player.transform.rotation = fwd;

        //Navi 카메라의 위치,회전값을 Aim 카메라로 이동
        UBStateMachine.player.AimVCam.ForceCameraPosition(
            UBStateMachine.player.NaviVCam.transform.position,
            UBStateMachine.player.NaviVCam.transform.rotation
            );

        //Aim 카메라 회전각 조정.
        aimCamPOV.m_HorizontalAxis.m_MinValue = fwd.eulerAngles.y - 50;
        aimCamPOV.m_HorizontalAxis.m_MaxValue = fwd.eulerAngles.y + 50;

        UBStateMachine.player.AimVCam.Priority = 20;

        //조준시 속도 계수 변화.
        LBStateMachine.MovementSpeedModifier2 *= UBStateMachine.player.playerSO.GroundData.AttackSpeed;

        UBStateMachine.AttackMode = true;
        UBStateMachine.player.crosshair.enabled = true;
        StartAnimation(LBStateMachine.player.AnimationData.UB_AttackParameterHash);
    }

    public override void Exit()
    {
        base.Exit();

        //내부 전환이면 건너뜀
        if (interTransition)
        {
            interTransition = false;
            return;
        }

        //Aim 카메라 회전각 조정.
        aimCamPOV.m_HorizontalAxis.m_MinValue = -560;
        aimCamPOV.m_HorizontalAxis.m_MaxValue = 560;

        //Aim 카메라의 위치,회전값을 Navi 카메라로 이동
        UBStateMachine.player.NaviVCam.ForceCameraPosition(
            UBStateMachine.player.AimVCam.transform.position,
            UBStateMachine.player.AimVCam.transform.rotation
            );

        UBStateMachine.player.AimVCam.Priority = 0;

        //조준 해제시 속도 원상복구.
        LBStateMachine.MovementSpeedModifier2 *= 1 / UBStateMachine.player.playerSO.GroundData.AttackSpeed;

        UBStateMachine.AttackMode = false;
        UBStateMachine.player.crosshair.enabled = false;
        StopAnimation(LBStateMachine.player.AnimationData.UB_AttackParameterHash);
    }

    //Quaternion spineWorldRot;

    public override void LateUpdate()
    {
        base.LateUpdate();

        //spine.transform.forward = Camera.main.transform.forward; // 실수
        //spine.rotation.SetLookRotation(Camera.main.transform.forward);

        //spine.rotation = Quaternion.Euler(Camera.main.transform.forward);
        //spineWorldRot = spine.rotation;

        //spine.rotation = Quaternion.LookRotation(quaternion * Camera.main.transform.forward);

        //Quaternion temp = Quaternion.LookRotation(Camera.main.transform.forward);
        //Quaternion temp2 = Quaternion.Inverse(spine.parent.rotation) * temp;
        //spine.localRotation = temp2;

        //spine.LookAt(spine.position + Camera.main.transform.forward);

        //spine.up = Camera.main.transform.forward;

        //spine.rotation = (Quaternion.Euler(UBStateMachine.player.vector));

        Quaternion baseRotation = Quaternion.Euler(180, 90, 90); // 예시 - 본의 기본 방향에 따라 다름
        Quaternion targetRotation = Quaternion.LookRotation(Camera.main.transform.forward);

        // 기본 회전을 고려하여 최종 회전 계산
        spine.rotation = targetRotation * baseRotation;

        //Quaternion baseRotation2 = Quaternion.Euler(-UBStateMachine.player.vector);
        //Quaternion targetRotation2 = Quaternion.LookRotation(Camera.main.transform.forward);
        //UBStateMachine.player.armRight.rotation = baseRotation2 * spine.rotation;

    }
}
