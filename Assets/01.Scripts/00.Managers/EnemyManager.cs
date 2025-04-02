using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoSingleton<EnemyManager>
{
    public GameObject EnemyObject;
    List<GameObject> Enemys = new List<GameObject>();

    public event Action OnDie;

    protected override void Awake()
    {
        base.Awake();
    }

    public void SpawnEnemy(GameObject spawnPosition)
    {
        GameObject gameObject = FindOffEnemy();

        if(gameObject == null) 
        {
            gameObject = Instantiate(EnemyObject, this.transform);
            Enemys.Add(gameObject);
        }

        gameObject.transform.position = spawnPosition.transform.position;
        gameObject.transform.eulerAngles = spawnPosition.transform.eulerAngles;
        gameObject.SetActive(true);
        gameObject.GetComponent<Enemy>().Init();
    }

    GameObject FindOffEnemy()
    {
        if (Enemys.Count == 0) return null;

        foreach(GameObject enemy in Enemys)
        {
            if (!enemy.activeSelf)
            {
                return enemy;
            }
        }
        return null;
    }

    public void Die()
    {
        OnDie?.Invoke();
    }
}
