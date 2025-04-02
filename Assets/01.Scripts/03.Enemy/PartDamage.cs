using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartDamage : MonoBehaviour
{
    public float MultToDamage;
    Collider partCollider;

    private void Awake()
    {
        partCollider = GetComponent<Collider>();
    }

    private void Start()
    {
        GetComponentInParent<Enemy>().Partscollider.Add(partCollider);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Bullet>())
        {
            //총 데미지를 계산하고 삭제
            GetComponentInParent<Enemy>().GetDamage(other.GetComponent<Bullet>().Damage * MultToDamage);
            other.GetComponent<Bullet>().DestroyThisObject();
        }
    }
}
