using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    public float Damage;
    float Speed = 20;
    Coroutine coroutine;

    Vector3 Tartget = new Vector3();
    public GameObject Particle;

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
            transform.localPosition += Tartget.normalized * Speed * Time.deltaTime;
            yield return null;
        }
    }

    public void DestroyThisObject()
    {
        StopCoroutine(coroutine);

        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy")) return;
        //무언가에 맞았을 때
        if (!(other.gameObject.GetComponentInParent<Player>() || other.gameObject.GetComponentInParent<Enemy>() || other.gameObject.GetComponent<Enemy>()))
        {
            //적,플레이어가 아닌 이상 튀기는 파티클과 함께 삭제
            GameObject par = Instantiate(Particle);
            par.transform.position = transform.position;
            DestroyThisObject();
        }
    }
}
