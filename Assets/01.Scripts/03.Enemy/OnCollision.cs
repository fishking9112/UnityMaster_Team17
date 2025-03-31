using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Bullet>())
        {
            gameObject.GetComponentInParent<Enemy>().OnColliders();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Bullet>())
        {
            gameObject.GetComponentInParent<Enemy>().OffColliders();
        }
    }
}
