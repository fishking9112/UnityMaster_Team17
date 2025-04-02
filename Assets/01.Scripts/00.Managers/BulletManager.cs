using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoSingleton<BulletManager>
{
    public GameObject BulletObject;
    List<GameObject> Bullets = new List<GameObject>();

    public GameObject RocketObject;
    List<GameObject> Rockets = new List<GameObject>();

    protected override void Awake()
    {
        base.Awake();
    }
    public GameObject SpawnBullet()
    {
        GameObject gameObject = FindOffBullet();

        if (gameObject == null)
        {
            gameObject = Instantiate(BulletObject, this.transform);
            Bullets.Add(gameObject);
        }

        gameObject.SetActive(true);
        return gameObject;
    }

    GameObject FindOffBullet()
    {
        if (Bullets.Count == 0) return null;

        foreach (GameObject bullet in Bullets)
        {
            if (!bullet.activeSelf)
            {
                return bullet;
            }
        }
        return null;
    }
    public GameObject SpawnRocket()
    {
        GameObject gameObject = FindOffRocket();

        if (gameObject == null)
        {
            gameObject = Instantiate(RocketObject, this.transform);
            Rockets.Add(gameObject);
        }

        gameObject.SetActive(true);
        return gameObject;
    }

    GameObject FindOffRocket()
    {
        if (Rockets.Count == 0) return null;

        foreach (GameObject rocket in Rockets)
        {
            if (!rocket.activeSelf)
            {
                return rocket;
            }
        }
        return null;
    }
}
