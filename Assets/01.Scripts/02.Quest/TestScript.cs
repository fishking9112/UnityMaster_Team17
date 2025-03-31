using System;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public event Action OnItemUsed;
    public event Action OnDie;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ChatManager.Instance.UpdateChatText(0);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            ChatManager.Instance.UpdateChatText(1);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            ChatManager.Instance.UpdateChatText(2);
        }
    }

    public void UseItem()
    {
        Debug.Log("아이템 사용");

        OnItemUsed?.Invoke();
    }

    public void EnemyDie()
    {
        Debug.Log("몬스터 사망");

        OnDie?.Invoke();
    }
}
