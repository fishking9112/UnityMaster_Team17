using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerAnimationData
{
    [SerializeField] private string DieParameterName = "Die";
    public int DieParameterHash { get; private set; }


    [Header("LowerBody")]
    [SerializeField] private string lb_GroundedParameterName = "@Grounded";
    [SerializeField] private string lb_IdleParameterName = "Idle";
    [SerializeField] private string lb_WalkParameterName = "Walk";
    [SerializeField] private string lb_RunParameterName = "Run";

    [SerializeField] private string lb_AirParameterName = "@Air";
    [SerializeField] private string lb_JumpParameterName = "Jump";
    [SerializeField] private string lb_FallParameterName = "Fall";
    [SerializeField] private string lb_LandingParameterName = "Landing";
    [SerializeField] private string lb_AscendParameterName = "Ascend";

    [SerializeField] private string lb_DashParameterName = "Dash";

    [SerializeField] private string lb_XParameterName = "X";
    [SerializeField] private string lb_YParameterName = "Y";

    public int LB_GroundedParameterHash { get; private set; }
    public int LB_IdleParameterHash { get; private set; }
    public int LB_WalkParameterHash { get; private set; }
    public int LB_RunParameterHash { get; private set; }

    public int LB_AirParameterHash { get; private set; }
    public int LB_JumpParameterHash { get; private set; }
    public int LB_FallParameterHash { get; private set; }
    public int LB_LandingParameterHash { get; private set; }
    public int LB_AscendParameterHash { get; private set; }

    public int LB_DashParameterHash { get; private set; }

    public int LB_XParameterHash { get; private set; }
    public int LB_YParameterHash { get; private set; }

    [Header("UpperBody")]
    [SerializeField] private string ub_ArmedParameterName = "@Armed";
    [SerializeField] private string ub_UnArmedParameterName = "@UnArmed";
    [SerializeField] private string ub_AttackParameterName = "@Attack";
    [SerializeField] private string ub_AimParameterName = "Aim";
    [SerializeField] private string ub_ShootParameterName = "Shoot";
    [SerializeField] private string ub_GrenadeParameterName = "Grenade";
    [SerializeField] private string ub_ReloadParameterName = "Reload";


    public int UB_ArmedParameterHash { get; private set; }
    public int UB_UnArmedParameterHash { get; private set; }
    public int UB_AttackParameterHash { get; private set; }
    public int UB_AimParameterHash { get; private set; }
    public int UB_ShootParameterHash { get; private set; }
    public int UB_GrenadeParameterHash { get; private set; }
    public int UB_ReloadParameterHash { get; private set; }

    public void Initialize()
    {
        DieParameterHash = Animator.StringToHash(DieParameterName);

        //LB
        LB_GroundedParameterHash = Animator.StringToHash(lb_GroundedParameterName);
        LB_IdleParameterHash = Animator.StringToHash(lb_IdleParameterName);
        LB_WalkParameterHash = Animator.StringToHash(lb_WalkParameterName);
        LB_RunParameterHash = Animator.StringToHash(lb_RunParameterName);

        LB_AirParameterHash = Animator.StringToHash(lb_AirParameterName);
        LB_JumpParameterHash = Animator.StringToHash(lb_JumpParameterName);
        LB_FallParameterHash = Animator.StringToHash(lb_FallParameterName);
        LB_LandingParameterHash = Animator.StringToHash(lb_LandingParameterName);
        LB_AscendParameterHash = Animator.StringToHash(lb_AscendParameterName);

        LB_DashParameterHash = Animator.StringToHash(lb_DashParameterName);

        LB_XParameterHash = Animator.StringToHash(lb_XParameterName);
        LB_YParameterHash = Animator.StringToHash(lb_YParameterName);

        //UB
        UB_ArmedParameterHash = Animator.StringToHash(ub_ArmedParameterName);
        UB_UnArmedParameterHash = Animator.StringToHash(ub_UnArmedParameterName);
        UB_AttackParameterHash = Animator.StringToHash(ub_AttackParameterName);
        UB_AimParameterHash = Animator.StringToHash(ub_AimParameterName);
        UB_ShootParameterHash = Animator.StringToHash(ub_ShootParameterName);
        UB_GrenadeParameterHash = Animator.StringToHash(ub_GrenadeParameterName);
        UB_ReloadParameterHash = Animator.StringToHash(ub_ReloadParameterName);
    }
}
