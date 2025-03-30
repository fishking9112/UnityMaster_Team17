using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[Serializable]
public class Enemy : MonoBehaviour
{
    [field: SerializeField] public EnemySO Data { get; private set; }

    [field: Header("Animations")]
    [field: SerializeField] public EnemyAnimationData AnimationData { get; private set; }
    public Animator animator{ get; private set; }
    public NavMeshAgent agent { get; private set; }
    public ForceReceiver ForceReceiver { get; private set; }

    [field: SerializeField] public GameObject EnemyRayPosition { get; private set; }
    [field: SerializeField] public GameObject EnemyShootPosition { get; private set; }
    [field: SerializeField] public GameObject Bullet { get; private set; }

    private EnemyStateMachine stateMachine;

    public GameObject Player;

    private void Awake()
    {
        AnimationData.Initialize();
        animator = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
        ForceReceiver = GetComponent<ForceReceiver>();

        stateMachine = new EnemyStateMachine(this, Player);
    }

    private void Start()
    {
        stateMachine.ChangeState(stateMachine.IdleState);
    }
    private void Update()
    {
        stateMachine.HanldeInput();
        stateMachine.Update();
    }

    private void FixedUpdate()
    {
        stateMachine.PhysicsUpdate();
    }

    public void ShootRiffle()
    {
        GameObject bullet = Instantiate(Bullet);
        bullet.transform.position = EnemyShootPosition.transform.position;
        bullet.GetComponent<Bullet>().SettingDamage(Data.Damage, gameObject.transform);
    }
}
