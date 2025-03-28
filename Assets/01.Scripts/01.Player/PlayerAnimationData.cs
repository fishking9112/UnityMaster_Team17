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

    public int LB_GroundedParameterHash { get; private set; }
    public int LB_IdleParameterHash {  get; private set; }
    public int LB_WalkParameterHash {  get; private set; }

    public void Initialize() 
    {
        LB_GroundedParameterHash = Animator.StringToHash(lb_GroundedParameterName);
        LB_IdleParameterHash = Animator.StringToHash(lb_IdleParameterName);
        LB_WalkParameterHash = Animator.StringToHash(lb_WalkParameterName);
    }



}
