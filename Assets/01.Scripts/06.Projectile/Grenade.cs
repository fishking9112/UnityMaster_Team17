using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float explosionRange;

    public GameObject explosionParticle;

    private GameObject curParticle;

    public float Damage;
    float Speed = 25;
    Coroutine coroutine;
    Vector3 Tartget = new Vector3();

    public void SettingDamage(float damage, Vector3 _tartget)
    {
        //처음 세팅 데미지와 방향
        Damage = damage;

        Tartget = _tartget;

        coroutine = StartCoroutine(ShootToTarget());
        Invoke("DestroyThisObject", 5f);
    }


    IEnumerator ShootToTarget()
    {
        while (true)
        {
            transform.localPosition += Tartget.normalized * (Speed + Time.deltaTime) * Time.deltaTime;
            yield return null;
        }
    }

    private void Explosion()
    {
        curParticle = Instantiate(explosionParticle, transform.position, transform.rotation);

        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRange);

        List<Collider> enemyColliders = new List<Collider>();

        foreach (var col in colliders)
        {
            if (col.CompareTag("Grenade_Target"))
            {
                enemyColliders.Add(col);
            }
        }

        foreach (var enemy in enemyColliders)
        {
            Vector3 direction = (enemy.transform.position - transform.position).normalized;

            RaycastHit hit;

            Debug.DrawRay(transform.position, direction * explosionRange, Color.red, 1f);

            if (Physics.Raycast(transform.position, direction, out hit, explosionRange))
            {
                if (hit.collider.gameObject.CompareTag("Grenade_Target"))
                {
                    hit.collider.GetComponentInParent<IDamageable>().GetDamage(30f);
                }
            }
        }

        gameObject.SetActive(false);
        Invoke("DestroyThisObject", 3f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRange);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Explosion();
    }

    public void DestroyThisObject()
    {
        StopCoroutine(coroutine);

        gameObject.SetActive(false);
    }

}
