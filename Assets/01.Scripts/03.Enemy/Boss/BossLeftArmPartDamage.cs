using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLeftArmPartDamage : BossPartDamage
{
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Bullet>())
        {
            //총 데미지를 계산하고 삭제
            GetComponentInParent<Boss>().LeftArmPartHp -= other.GetComponent<Bullet>().Damage * MultToDamage;
            GetComponentInParent<Boss>().GetDamage(other.GetComponent<Bullet>().Damage * MultToDamage);
            other.GetComponent<Bullet>().DestroyThisObject();
        }
    }
}
