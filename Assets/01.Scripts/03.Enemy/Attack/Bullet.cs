using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    public float Damage;
    float Speed = 10;

    Vector3 targetToPlayer = new Vector3();
    public GameObject Particle;

    GameObject Player;

    private void Start()
    {
        Invoke("DestroyThisObject", 10f);
    }

    public void SettingDamage(float damage, Transform ene)
    {
        Damage = damage;

        targetToPlayer = Player.transform.position - ene.position + new Vector3(Random.Range(-3f,3f), Random.Range(-3f, 3f) + 1, Random.Range(-3f, 3f));
    }

    private void Update()
    {
        transform.localPosition += targetToPlayer.normalized * Speed * Time.deltaTime;
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
        else
        {
            GameObject par = Instantiate(Particle);
            par.transform.position = transform.position;
        }
        DestroyThisObject();
    }
}
