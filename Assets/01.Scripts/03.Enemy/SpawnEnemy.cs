using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    private void Start()
    {
        InvokeRepeating("Spawn", 0, 2);
    }

    private void Spawn()
    {
        EnemyManager.Instance.SpawnEnemy(this.gameObject);

    }
}
