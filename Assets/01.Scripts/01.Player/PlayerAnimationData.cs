using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerAnimationData
{
    [SerializeField] private string groundedParameterName = "@Grounded";
    [SerializeField] private string idleParameterName = "Idle";
    [SerializeField] private string walkParameterName = "Walk";

    public int GroundedParameterHash { get; private set; }
    public int IdleParameterHash {  get; private set; }
    public int WalkParameterHash {  get; private set; }

    public void Initialize() 
    {
        GroundedParameterHash = Animator.StringToHash(groundedParameterName);
        IdleParameterHash = Animator.StringToHash(idleParameterName);
        WalkParameterHash = Animator.StringToHash(walkParameterName);
    }



}
