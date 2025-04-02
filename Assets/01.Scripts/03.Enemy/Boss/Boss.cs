using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour, IDamageable
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
    private bool isHalf = false;

    public GameObject RightArm;
    public bool IsRightArm;
    public float RightArmPartHp;
    public GameObject LeftArm;
    public bool IsLeftArm;
    public float LeftArmPartHp;

    public float LastGunAttack;
    public float GunRate;
    public float LastRocketAttack;
    public float RocketRate;
    public float LastMiliAttack;
    public float MiliRate;

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

        LeftArmPartHp = Data.Hp / 4;
        RightArmPartHp = Data.Hp / 4;

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
    void ShootRiffle()
    {
        //총을 총구에서 쏘도록 제작
        GameObject bullet = BulletManager.Instance.SpawnBullet();
        bullet.transform.position = BossRightShootPosition.transform.position;
        bullet.transform.rotation = Quaternion.LookRotation((GameManager.Instance.player.transform.position - BossRightShootPosition.transform.position).normalized);
        bullet.GetComponent<Bullet>().SettingDamage(Data.Damage,
            GameManager.Instance.player.transform.position - BossRightShootPosition.transform.position +
            new Vector3(UnityEngine.Random.Range(-0.5f, 0.5f), UnityEngine.Random.Range(-0.5f, 0.5f) + 1, UnityEngine.Random.Range(-0.5f, 0.5f)));
    }
    void ShootRocket()
    {
        //로켓을 왼속에서 발싸
        GameObject Rocket = BulletManager.Instance.SpawnRocket();
        Rocket.transform.position = BossLeftShootPosition.transform.position;
        Rocket.transform.rotation = Quaternion.LookRotation((GameManager.Instance.player.transform.position - BossLeftShootPosition.transform.position).normalized);
        Rocket.GetComponent<Grenade>().SettingDamage(Data.Damage * 5,
            GameManager.Instance.player.transform.position - BossLeftShootPosition.transform.position +
            new Vector3(UnityEngine.Random.Range(-0.1f, 0.1f), UnityEngine.Random.Range(-0.1f, 0.1f) + 1, UnityEngine.Random.Range(-0.1f, 0.1f)));
    }

    public void Riffle()
    {
        LastGunAttack = Time.time;
        GunRate = Random.Range(5f, 10f);

        StartCoroutine(coroutineRiffle());
    }

    IEnumerator coroutineRiffle()
    {
        int i = 0;

        while (i < 20)
        {
            ShootRiffle();
            i++;
            yield return new WaitForSeconds(0.2f);
        }

        stateMachine.ChangeState(stateMachine.IdleState);
    }
    public void Rocket()
    {
        LastRocketAttack = Time.time;
        RocketRate = Random.Range(20f, 30f);

        StartCoroutine(coroutineRocket());
    }

    IEnumerator coroutineRocket()
    {
        int i = 0;

        while (i < 5)
        {
            ShootRocket();
            i++;
            yield return new WaitForSeconds(1f);
        }

        stateMachine.ChangeState(stateMachine.IdleState);
    }

    public void InvokeMiliAttack()
    {
        Invoke("MiliAttack", 1f);
    }

    void MiliAttack()
    {
        if ((GameManager.Instance.player.transform.position - transform.position).sqrMagnitude < Data.AttackRange * 2)
        {
            //데미지를 준다
        }

        stateMachine.ChangeState(stateMachine.IdleState);
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

    public void GetDamage(float amount)
    {
        HP -= amount * GetDamageMultiple;

        if (LeftArmPartHp == 0 && IsLeftArm)
        {
            IsLeftArm = false;
            LeftArm.SetActive(false);
            StopAllCoroutines();
            animator.SetTrigger(AnimationData.LeftHitParameterHash);
            stateMachine.ChangeState(stateMachine.ChaseState);
        }
        else if (RightArmPartHp == 0 && IsRightArm)
        {
            IsRightArm = false;
            RightArm.SetActive(false);
            StopAllCoroutines();
            animator.SetTrigger(AnimationData.RightHitParameterHash);
            stateMachine.ChangeState(stateMachine.ChaseState);
        }
        else if (HP <= MaxHP / 2 && !isHalf)
        {
            //그로기
            isHalf = true;
            StopAllCoroutines();
            animator.SetTrigger(AnimationData.HalfHitParameterHash);
            stateMachine.ChangeState(stateMachine.ChaseState);
        }
        else if (HP <= 0)
        {
            //사망
            EnemyManager.Instance.Die();

            HP = 0;
            StopAllCoroutines();
            OffColliders();
            stateMachine.ChangeState(stateMachine.DeadState);
        }
        else
        {
            //맞고 살았을 경우
            Invoke("OffColliders", 0.01f);
            stateMachine.ChangeState(stateMachine.ChaseState);
        }
    }
}
