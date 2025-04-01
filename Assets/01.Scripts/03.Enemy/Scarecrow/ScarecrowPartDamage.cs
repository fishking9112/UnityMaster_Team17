using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScarecrowPartDamage : MonoBehaviour
{
    public float MultToDamage;
    Collider partCollider;

    private void Awake()
    {
        partCollider = GetComponent<Collider>();
    }

    private void Start()
    {
        GetComponentInParent<Scarecrow>().Partscollider.Add(partCollider);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Bullet>())
        {
            //총 데미지를 계산하고 삭제
            GetComponentInParent<Scarecrow>().GetDamage(other.GetComponent<Bullet>().Damage * MultToDamage);
            other.GetComponent<Bullet>().DestroyThisObject();
        }
    }
}
