using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BossAnimationData
{
    [SerializeField] private string StartParameterName = "@Start";
    [SerializeField] private string IsOnParameterName = "IsOn";
    [SerializeField] private string IdleParameterName = "@Idle";
    [SerializeField] private string IsChaseParameterName = "IsChase";
    [SerializeField] private string AttackParameterName = "@Attack";
    [SerializeField] private string IsLeftFootParameterName = "IsLeftFoot";
    [SerializeField] private string IsRightFootParameterName = "IsRightFoot";
    [SerializeField] private string IsDeadParameterName = "IsDead";
    [SerializeField] private string RightHitParameterName = "RightHit";
    [SerializeField] private string LeftHitParameterName = "LeftHit";
    [SerializeField] private string HalfHitParameterName = "HalfHit";

    public int StartParameterHash { get; private set; }
    public int IsOnParameterHash { get; private set; }
    public int IdleParameterHash { get; private set; }
    public int IsChaseParameterHash { get; private set; }
    public int AttackParameterHash { get; private set; }
    public int IsLeftFootParameterHash { get; private set; }
    public int IsRightFootParameterHash { get; private set; }
    public int IsDeadParameterHash { get; private set; }
    public int RightHitParameterHash { get; private set; }
    public int LeftHitParameterHash { get; private set; }
    public int HalfHitParameterHash { get; private set; }

    public void Initialize()
    {
        StartParameterHash = Animator.StringToHash(StartParameterName);
        IsOnParameterHash = Animator.StringToHash(IsOnParameterName);
        IdleParameterHash = Animator.StringToHash(IdleParameterName);
        IsChaseParameterHash = Animator.StringToHash(IsChaseParameterName);
        AttackParameterHash = Animator.StringToHash(AttackParameterName);
        IsLeftFootParameterHash = Animator.StringToHash(IsLeftFootParameterName);
        IsRightFootParameterHash = Animator.StringToHash(IsRightFootParameterName);
        IsDeadParameterHash = Animator.StringToHash(IsDeadParameterName);
        RightHitParameterHash = Animator.StringToHash(RightHitParameterName);
        LeftHitParameterHash = Animator.StringToHash(LeftHitParameterName);
        HalfHitParameterHash = Animator.StringToHash(HalfHitParameterName);
    }
}
