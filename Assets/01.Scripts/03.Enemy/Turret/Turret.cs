using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour, IDamageable
{
    public GameObject TurretShootPosition;
    public float HP;
    public float Damage;
    private TurretStateMachine stateMachine;

    public GameObject DeadHeadBone;
    public GameObject TurnHeadPosition;

    public float ChasingMaxRange;
    public float SeightAngle;
    public float AttackRate;

    [field: Header("GetDamage")]
    public List<Collider> Partscollider; //모든 부위의 collider들

    private void Start()
    {
        stateMachine = new TurretStateMachine(this);

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
        //총을 총구에서 쏘도록 제작
        GameObject bullet = BulletManager.Instance.SpawnBullet();
        SoundManager.Instance.PlayerSFX("Player_Shoot_SFX", TurretShootPosition.transform.position);
        bullet.transform.position = TurretShootPosition.transform.position;
        bullet.transform.rotation = Quaternion.LookRotation((GameManager.Instance.player.transform.position - TurretShootPosition.transform.position).normalized);
        bullet.GetComponent<Bullet>().SettingDamage(Damage,
            GameManager.Instance.player.transform.position - TurretShootPosition.transform.position + new Vector3(0, 1, 0));
    }

    public void GetDamage(float amount)
    {
        if (HP <= 0) return;

        HP -= amount;

        if (HP <= 0)
        {
            //맞고 죽을 경우
            EnemyManager.Instance.Die();

            HP = 0;
            stateMachine.ChangeState(stateMachine.DeadState);
            SoundManager.Instance.PlayerSFX("Turret_Die_SFx", transform.position);
            StartCoroutine(DeadMotion());
        }
    }

    IEnumerator DeadMotion()
    {
        while (DeadHeadBone.transform.eulerAngles.x < 300)
        {
            DeadHeadBone.transform.localEulerAngles += new Vector3(1, 0, 0) * 30 * Time.deltaTime;
            yield return null;
        }
    }
}
