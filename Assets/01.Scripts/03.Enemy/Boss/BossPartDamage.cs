using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPartDamage : MonoBehaviour
{
    public float MultToDamage;
    Collider partCollider;

    private void Awake()
    {
        partCollider = GetComponent<Collider>();
    }

    private void Start()
    {
        GetComponentInParent<Boss>().Partscollider.Add(partCollider);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Bullet>())
        {
            //총 데미지를 계산하고 삭제
            GetComponentInParent<Boss>().GetDamage(other.GetComponent<Bullet>().Damage * MultToDamage);
            other.GetComponent<Bullet>().DestroyThisObject();
        }
    }
}
