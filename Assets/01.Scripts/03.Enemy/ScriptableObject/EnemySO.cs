using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Characters/Enemy")]
public class EnemySO : ScriptableObject
{
    public float NormalSpeed = 1f;
    public float RunSpeed = 1.5f;
    public float RotationDamping = 1f;

    public float EnemySightAngle = 60f;

    public float PlayerChasingRange;
    public float AttackRange;
    public float RemainAttackRange;

    [Header("State")]
    public float Hp;
    public float Damage;
    public float AttackRate;
}
