using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemyAnimationData
{
    [SerializeField] private string ChasingParameterName = "Chasing";
    [SerializeField] private string ShootParameterName = "Shoot";

    public int ChasingParameterHash { get; private set; }
    public int ShootParameterHash { get; private set; }

    public void Initialize()
    {
        ChasingParameterHash = Animator.StringToHash(ChasingParameterName);
        ShootParameterHash = Animator.StringToHash(ShootParameterName);
    }
}
