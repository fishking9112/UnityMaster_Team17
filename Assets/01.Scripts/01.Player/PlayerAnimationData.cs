using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerAnimationData
{
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

    public int LB_GroundedParameterHash { get; private set; }
    public int LB_IdleParameterHash {  get; private set; }
    public int LB_WalkParameterHash {  get; private set; }
    public int LB_RunParameterHash {  get; private set; }

    public int LB_AirParameterHash {  get; private set; }
    public int LB_JumpParameterHash {  get; private set; }
    public int LB_FallParameterHash {  get; private set; }
    public int LB_LandingParameterHash {  get; private set; }
    public int LB_AscendParameterHash {  get; private set; }

    public void Initialize() 
    {
        LB_GroundedParameterHash = Animator.StringToHash(lb_GroundedParameterName);
        LB_IdleParameterHash = Animator.StringToHash(lb_IdleParameterName);
        LB_WalkParameterHash = Animator.StringToHash(lb_WalkParameterName);
        LB_RunParameterHash = Animator.StringToHash(lb_RunParameterName);

        LB_AirParameterHash = Animator.StringToHash(lb_AirParameterName);
        LB_JumpParameterHash = Animator.StringToHash(lb_JumpParameterName);
        LB_FallParameterHash = Animator.StringToHash(lb_FallParameterName);
        LB_LandingParameterHash = Animator.StringToHash(lb_LandingParameterName);
        LB_AscendParameterHash = Animator.StringToHash(lb_AscendParameterName);
    }
}
