using System;
using Unity.VisualScripting;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public event Action OnItemUsed;
    public event Action OnDie;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            UseItem();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            Die();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            QuestManager.Instance.QuestReset();
        }
    }

    public void UseItem()
    {
        Debug.Log("아이템 사용");

        OnItemUsed?.Invoke();
    }

    public void Die()
    {
        Debug.Log("몬스터 사망");

        OnDie?.Invoke();
    }
}
