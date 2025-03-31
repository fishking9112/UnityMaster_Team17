using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject TurretShootPosition;
    public float HP;
    public float Damage;
    private TurretStateMachine stateMachine;

    public GameObject DeadHeadBone;
    public GameObject TurnHeadPosition;
    public float ChasingMaxRange;

    private void Start()
    {
        stateMachine = new TurretStateMachine(this);
    }
    public void ShootRiffle()
    {
        //총을 총구에서 쏘도록 제작
        GameObject bullet = BulletManager.Instance.SpawnBullet();
        bullet.transform.position = TurretShootPosition.transform.position;
        bullet.GetComponent<Bullet>().SettingDamage(Damage, TurretShootPosition.transform);
    }

    public void GetDamage(float amount)
    {
        HP -= amount;

        if (HP <= 0)
        {
            //맞고 죽을 경우
            HP = 0;
            StartCoroutine(DeadMotion());
        }
    }

    IEnumerator DeadMotion()
    {
        while(DeadHeadBone.transform.eulerAngles.x < 300)
        {
            DeadHeadBone.transform.eulerAngles += new Vector3(1, 0, 0) * 30 * Time.deltaTime;
            yield return null;
        }
    }
}
