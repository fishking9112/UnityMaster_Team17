using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    public float Damage;
    float Speed = 10;
    Coroutine coroutine;

    Vector3 targetToPlayer = new Vector3();
    public GameObject Particle;

    public void SettingDamage(float damage, Transform ene)
    {
        //처음 세팅 데미지와 방향
        Damage = damage;

        targetToPlayer = GameManager.Instance.player.transform.position - ene.position + new Vector3(Random.Range(-2f,2f), Random.Range(-2f, 2f) + 1, Random.Range(-2f, 2f));

        coroutine = StartCoroutine(ShootToTarget());
        Invoke("DestroyThisObject", 5f);
    }


    IEnumerator ShootToTarget()
    {
        while (true)
        {
            transform.localPosition += targetToPlayer.normalized * Speed * Time.deltaTime;
            yield return null;
        }
    }

    public void DestroyThisObject()
    {
        StopCoroutine(coroutine);

        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //무언가에 맞았을 때
        if(!(collision.gameObject.GetComponentInParent<Player>() || collision.gameObject.GetComponentInParent<Enemy>() || collision.gameObject.GetComponent<Enemy>()))
        {
            //적,플레이어가 아닌 이상 튀기는 파티클과 함께 삭제
            GameObject par = Instantiate(Particle);
            par.transform.position = transform.position;
            DestroyThisObject();
        }
    }
}
