using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGetDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Bullet>())
        {
            //총 데미지를 계산하고 삭제
            GetComponentInParent<Player>().GetDamage(other.GetComponent<Bullet>().Damage);
            other.GetComponent<Bullet>().DestroyThisObject();
        }
    }
}
