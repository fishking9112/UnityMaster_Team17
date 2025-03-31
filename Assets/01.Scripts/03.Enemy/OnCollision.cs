using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Bullet>())
        {
            gameObject.GetComponentInParent<Enemy>().OnColliders();
            gameObject.GetComponent<Collider>().enabled = false;
        }
    }
}
