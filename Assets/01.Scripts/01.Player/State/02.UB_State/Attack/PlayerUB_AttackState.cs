using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUB_AttackState : PlayerUB_BaseState
{
    public Transform spine;
    public Transform Hip;
    CinemachinePOV aimCamPOV;
    //CinemachinePOV naviCamPOV;

    public bool interTransition;

    public PlayerUB_AttackState(PlayerLBStateMachine LBstateMachine, PlayerUBStateMachine UBStateMachine) : base(LBstateMachine, UBStateMachine)
    {
        spine = UBStateMachine.player.Animator.GetBoneTransform(HumanBodyBones.Spine);
        Hip = UBStateMachine.player.Animator.GetBoneTransform(HumanBodyBones.Hips);
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




        //Aim 카메라 최소최대회전각 조정.

        float characterYRotation = UBStateMachine.player.transform.rotation.eulerAngles.y;

        // 제한각 설정 (좌우 50도)
        aimCamPOV.m_HorizontalAxis.m_MinValue = characterYRotation - 50f;
        aimCamPOV.m_HorizontalAxis.m_MaxValue = characterYRotation + 50f;

        // 현재 POV 값을 캐릭터 방향으로 리셋 (필수사항)
        aimCamPOV.m_HorizontalAxis.Value = characterYRotation;



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
        UBStateMachine.player.armRight.transform.SetParent(Hip, false);

    }

    //Quaternion spineWorldRot;

    public override void LateUpdate()
    {
        base.LateUpdate();

        Quaternion baseRotation = Quaternion.Euler(180, 90, 90); // 본이 정면을 바라볼 수 있게하는 방향
        Quaternion targetRotation = Quaternion.LookRotation(Camera.main.transform.forward); // 목표 방향

        // 기본 회전을 고려하여 최종 회전 계산
        spine.rotation = targetRotation * baseRotation;

        Quaternion baseRotation2 = Quaternion.Euler(UBStateMachine.player.vectorRot);
        Vector3 basePosition = spine.position;

        //Quaternion targetRotation2 = Quaternion.LookRotation(Camera.main.transform.forward);

        //UBStateMachine.player.armRight.rotation = targetRotation * baseRotation2;
        //UBStateMachine.player.armRight.position = spine.position + UBStateMachine.player.vectorPos;
        
        UBStateMachine.player.armRight.transform.SetParent(spine, true);
        UBStateMachine.player.armRight.transform.localRotation = baseRotation2;
        UBStateMachine.player.armRight.transform.localPosition = UBStateMachine.player.vectorPos;

    }
}
