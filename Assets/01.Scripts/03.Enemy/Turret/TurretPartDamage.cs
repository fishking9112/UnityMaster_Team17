using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPartDamage : MonoBehaviour
{
    public float MultToDamage;
    Collider partCollider;

    private void Awake()
    {
        partCollider = GetComponent<Collider>();
    }

    private void Start()
    {
        GetComponentInParent<Turret>().Partscollider.Add(partCollider);
        partCollider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Bullet>())
        {
            //총 데미지를 계산하고 삭제
            GetComponentInParent<Turret>().GetDamage(other.GetComponent<Bullet>().Damage * MultToDamage);
            other.GetComponent<Bullet>().DestroyThisObject();
        }
    }
}
