using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float explosionRange;

    public GameObject explosionParticle;

    private GameObject curParticle;

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
        Invoke("DelayDestroy", 3f);
    }

    private void DelayDestroy()
    {
        Destroy(curParticle);
        Destroy(this.gameObject);
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
}
