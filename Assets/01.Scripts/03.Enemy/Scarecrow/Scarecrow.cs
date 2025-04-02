using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scarecrow : MonoBehaviour, IDamageable
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
            EnemyManager.Instance.Die();

            HP = 0;
            animator.SetTrigger("IsDead");
            OffColliders();
            StartCoroutine(ReSpawnScarecrow());
        }
        else
        {
            animator.SetTrigger("GetHit");
            SoundManager.Instance.PlayerSFX("Scarecrow_Die_SFX", transform.position);
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
