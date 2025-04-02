using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossOnCollision : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Bullet>())
        {
            gameObject.GetComponentInParent<Boss>().OnColliders();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Bullet>())
        {
            gameObject.GetComponentInParent<Boss>().OffColliders();
        }
    }
}
