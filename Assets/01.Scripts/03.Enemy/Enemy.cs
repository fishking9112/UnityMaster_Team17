using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemySO Data { get; private set; }
    public EnemyAnimationData AnimationData { get; private set; }
    public Animator animator;

    private void Awake()
    {
        AnimationData.Initialize();
        animator = GetComponentInChildren<Animator>();
    }
}
