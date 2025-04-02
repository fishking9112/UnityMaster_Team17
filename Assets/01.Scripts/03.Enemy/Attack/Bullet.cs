using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    public float Damage;
    float Speed = 40;
    Coroutine coroutine;

    Vector3 Tartget = new Vector3();
    public GameObject Particle;
    public GameObject PlayerHitParticle;
    public GameObject EnemyHitParticle;
    public GameObject RobotHitParticle;

    public void SettingDamage(float damage, Vector3 _tartget)
    {
        //처음 세팅 데미지와 방향
        Damage = damage;

        Tartget = _tartget;

        coroutine = StartCoroutine(ShootToTarget());
        GetComponent<TrailRenderer>().Clear();
        
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
        if(other.gameObject.layer == 9)
        {
            return;
        }
        else if (other.gameObject.GetComponentInParent<Player>())
        {
            GameObject par = Instantiate(PlayerHitParticle);
            SoundManager.Instance.PlayerSFX("Player_Damage_SFX", transform.position);
            par.transform.position = transform.position;
            par.transform.rotation = transform.rotation;
        }
        else if (other.gameObject.GetComponentInParent<Enemy>())
        {
            GameObject par = Instantiate(EnemyHitParticle);
            par.transform.position = transform.position;
            par.transform.rotation = transform.rotation;
        }
        else if (other.gameObject.layer == 8)
        {
            SoundManager.Instance.PlayerSFX("Metal_Hit_SFX", transform.position);
            GameObject par = Instantiate(RobotHitParticle);
            par.transform.position = transform.position;
            par.transform.rotation = transform.rotation;
        }
        else
        {
            //적,플레이어가 아닌 이상 튀기는 파티클과 함께 삭제
            SoundManager.Instance.PlayerSFX("Wall_Hit_SFX", transform.position);
            GameObject par = Instantiate(Particle);
            par.transform.position = transform.position;
            DestroyThisObject();
        }
    }
}
