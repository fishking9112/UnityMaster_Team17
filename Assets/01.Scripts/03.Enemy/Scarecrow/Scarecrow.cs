using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scarecrow : MonoBehaviour
{
    public Animator animator;
    public float HP;
    private float MaxHP;

    public List<Collider> Partscollider; //모든 부위의 collider들

    private void Start()
    {
        MaxHP = HP;
    }

    public void GetDamage(float amount)
    {
        HP -= amount;

        if (HP <= 0)
        {
            //맞고 죽을 경우
            HP = 0;
            animator.SetTrigger("IsDead");
            OffColliders();
            StartCoroutine(ReSpawnScarecrow());
        }
        else
        {
            animator.SetTrigger("GetHit");
        }
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

    IEnumerator ReSpawnScarecrow()
    {
        yield return new WaitForSeconds(1.5f);
        HP = MaxHP;
        OnColliders();
    }
}
