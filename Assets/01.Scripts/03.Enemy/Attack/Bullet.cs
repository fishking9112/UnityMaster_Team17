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

    private void Start()
    {
        //일정 시간이 지나면 자동으로 삭제
        Invoke("DestroyThisObject", 10f);
    }

    public void SettingDamage(float damage, Transform ene)
    {
        //처음 세팅 데미지와 방향
        Damage = damage;

        targetToPlayer = GameManager.Instance.player.transform.position - ene.position + new Vector3(Random.Range(-2f,2f), Random.Range(-2f, 2f) + 1, Random.Range(-2f, 2f));
    }

    private void Update()
    {
        //계산된 범위로 날아간다
        transform.localPosition += targetToPlayer.normalized * Speed * Time.deltaTime;
    }

    void DestroyThisObject()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //무언가에 맞았을 때

        if (collision.gameObject.GetComponentInParent<Player>())
        {
            Debug.Log("Hit");
            //데미지를 준다
        }
        else
        {
            //적,플레이어가 아닌 이상 튀기는 파티클과 함께 삭제
            GameObject par = Instantiate(Particle);
            par.transform.position = transform.position;
        }
        DestroyThisObject();
    }
}
