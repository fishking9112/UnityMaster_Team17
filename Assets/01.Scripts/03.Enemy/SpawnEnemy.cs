using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        EnemyManager.Instance.SpawnEnemy(this.gameObject);

    }
}
