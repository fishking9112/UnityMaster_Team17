using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationData : MonoBehaviour
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
