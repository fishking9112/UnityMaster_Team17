using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerUseItem : MonoBehaviour
{
    PlayerCondition playerCondition;

    public event Action OnGrenadeUsed;
    public event Action OnRepairKitUsed;

    private void Start()
    {
        playerCondition = GetComponent<PlayerCondition>();
        AddUseGrenadeCallback();
        AddUseRepairKitCallback();
    }

    private void AddUseGrenadeCallback()
    {
        GameManager.Instance.player.Input.playerActions.Grenade.started += OnUseGrenadeStared;
    }

    private void AddUseRepairKitCallback()
    {
        GameManager.Instance.player.Input.playerActions.RepairKit.started += OnUseRepairKitStared;
    }

    public void OnUseGrenadeStared(InputAction.CallbackContext context)
    {
        if(playerCondition.CurGrenadeCount > 0)
        {
            Debug.Log("유탄 발사");

            playerCondition.SubGrenade(1);
            OnGrenadeUsed?.Invoke();

            // 유탄 발사 
        }
        else
        {
            Debug.Log("유탄이 부족합니다.");
        }
    }

    public void OnUseRepairKitStared(InputAction.CallbackContext context)
    {
        if (playerCondition.CurRepairKitCount > 0)
        {
            Debug.Log("수리 키트 사용");

            playerCondition.SubRepairKit(1);
            OnRepairKitUsed?.Invoke();

            // 수리 키트 사용
        }
        else
        {
            Debug.Log("수리 키트가 부족합니다.");
        }
    }
}
