using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Damage;
    float Speed = 10;

    public void SettingDamage(float damage)
    {
        Damage = damage;
    }   

    private void Start()
    {
        Invoke("DestroyThisObject", 10f);
    }

    private void Update()
    {
        transform.localPosition += gameObject.transform.rotation * Vector3.forward * Speed * Time.deltaTime;
    }

    void DestroyThisObject()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            //데미지를 준다
        }
        DestroyThisObject();
    }
}
