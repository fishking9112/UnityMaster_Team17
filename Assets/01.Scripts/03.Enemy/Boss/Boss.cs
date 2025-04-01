using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{
    [field: SerializeField] public EnemySO Data { get; private set; }

    [field: Header("Animations")]
    [field: SerializeField] public BossAnimationData AnimationData { get; private set; }
    public Animator animator { get; private set; }
    public NavMeshAgent agent { get; private set; }

    [field: Header("Seight")]
    [field: SerializeField] public GameObject BossRayPosition { get; private set; }
    [field: SerializeField] public GameObject BossLeftShootPosition { get; private set; }
    [field: SerializeField] public GameObject BossRightShootPosition { get; private set; }

    [field: Header("GetDamage")]
    public List<Collider> Partscollider; //모든 부위의 collider들
    public float GetDamageMultiple;

    private BossStateMachine stateMachine;

    private float HP;
    private float MaxHP;

    public GameObject RightArm;
    public bool IsRightArm;
    public GameObject LeftArm;
    public bool IsLeftArm;

    public float LastGunAttack;
    public float GunRate;
    public float LastRocketAttack;
    public float RocketRate;

    public float LastMiliAttack;

    private void Awake()
    {
        AnimationData.Initialize();
        animator = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        stateMachine = new BossStateMachine(this);

        stateMachine.ChangeState(stateMachine.StartState);

        //체력값 받아오기
        HP = Data.Hp;
        MaxHP = Data.Hp;

        GetDamageMultiple = 0.1f;

        IsRightArm = true;
        IsLeftArm = true;
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
        //총을 총구에서 쏘도록 제작
        GameObject bullet = BulletManager.Instance.SpawnBullet();
        bullet.transform.position = BossRightShootPosition.transform.position;
        bullet.GetComponent<Bullet>().SettingDamage(Data.Damage,
            GameManager.Instance.player.transform.position - BossRightShootPosition.transform.position +
            new Vector3(UnityEngine.Random.Range(-0.5f, 0.5f), UnityEngine.Random.Range(-0.5f, 0.5f) + 1, UnityEngine.Random.Range(-0.5f, 0.5f)));
    }

    public void GetDamage(float amount)
    {
        HP -= amount * GetDamageMultiple;

        if (HP <= 0)
        {
            HP = 0;
        }
        else if(HP <= MaxHP / 2)
        {

        }
    }
}
