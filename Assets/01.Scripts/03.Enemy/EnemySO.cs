using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Characters/Enemy")]
public class EnemySO : ScriptableObject
{
    public float PlayerChasingRange { get; private set; }
    public float AttackRange { get; private set; }
    public float RemainAttackRange { get; private set; }
    public float Damage { get; private set; }
    public float AttackRate { get; private set; }
}
