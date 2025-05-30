using System;
using UnityEngine;

[Serializable]
public class PlayerGroundData
{

    [field: SerializeField, Range(0f, 25f)] public float BaseSpeed { get; private set; } = 5f;
    [field: SerializeField, Range(0f, 25f)] public float RotationDamping { get; private set; } = 5f;
    [field: SerializeField, Range(0f, 2f)] public float AttackSpeed { get; private set; } = 0.5f;

    [field: Header("WalkData")]
    [field: SerializeField, Range(0f, 2)] public float WalkSpeed { get; private set; } = 0.225f;

    [field: Header("RunData")]
    [field: SerializeField, Range(0f, 2f)] public float RunSpeed { get; private set; } = 1;
}

[Serializable]
public class PlayerAirData
{
    [field: Header("JumpData")]
    [field: SerializeField, Range(0f, 100f)] public float JumpForce { get; private set; } = 3f;
}

[CreateAssetMenu(fileName = "NewPlayerSO", menuName = "Character/Player")]
public class PlayerSO : ScriptableObject
{
    [field: SerializeField] public PlayerGroundData GroundData { get; private set; }
    [field: SerializeField] public PlayerAirData AirData { get; private set; }
    [field: Header("DashData")]
    [field: SerializeField, Range(10f, 50f)] public float DashSpeed { get; private set; }
    [field: SerializeField, Range(1f, 20f)] public float FireRPS { get; private set; }
}