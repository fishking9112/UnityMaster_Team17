using Google.GData.Extensions;
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

    [field: Header("Seight")]
    [field: SerializeField] public GameObject EnemyRayPosition { get; private set; }
    [field: SerializeField] public GameObject EnemyShootPosition { get; private set; }

    [field: Header("GetDamage")]
    public List<Collider> Partscollider; //모든 부위의 collider들

    private EnemyStateMachine stateMachine;

    private float HP;
    private float MaxHP;

    private void Awake()
    {
        AnimationData.Initialize();
        animator = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
        ForceReceiver = GetComponent<ForceReceiver>();
    }

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        stateMachine = new EnemyStateMachine(this, GameManager.Instance.player.gameObject);

        stateMachine.ChangeState(stateMachine.IdleState);

        //체력값 받아오기
        HP = Data.Hp;
        MaxHP = Data.Hp;

        OffColliders();
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

    public void OnColliders()
    {
        foreach (Collider col in Partscollider)
        {
            col.enabled = true;
        }
    }
    public void OffColliders()
    {
        foreach (Collider col in Partscollider)
        {
            col.enabled = false;
        }
    }

    public void ShootRiffle()
    {
        //총을 총구에서 쏘도록 제작
        GameObject bullet = BulletManager.Instance.SpawnBullet();
        bullet.transform.position = EnemyShootPosition.transform.position;
        bullet.GetComponent<Bullet>().SettingDamage(Data.Damage, EnemyShootPosition.transform);
    }

    public void GetDamage(float amount)
    {
        HP -= amount;

        if (HP <= 0)
        {
            //맞고 죽을 경우
            HP = 0;
            stateMachine.ChangeState(stateMachine.DeadState);
            Invoke("DisSpawnEnemy", 1);
        }
        else
        {
            //맞고 살았을 경우
            Invoke("OffColliders", 0.01f);
            stateMachine.ChangeState(stateMachine.ChaseState);
        }
    }

    void DisSpawnEnemy()
    {
        gameObject.SetActive(false);
    }
}
