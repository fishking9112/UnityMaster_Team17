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
        AddUseRepairKitCallback();
    }

    private void AddUseRepairKitCallback()
    {
        GameManager.Instance.player.Input.playerActions.RepairKit.started += OnUseRepairKitStared;
    }

    public void ShootRocket()
    {
        if (playerCondition.CurGrenadeCount > 0)
        {
            Debug.Log("유탄 발사");

            playerCondition.SubGrenade(1);
            OnGrenadeUsed?.Invoke();

            //로켓을 왼속에서 발싸
            GameObject Rocket = BulletManager.Instance.SpawnRocket();
            Rocket.transform.position = GameManager.Instance.player.TargetingHandler.bulletStartPos.position;
            Rocket.transform.rotation = Quaternion.LookRotation((GameManager.Instance.player.TargetingHandler.bulletTargetPos - GameManager.Instance.player.TargetingHandler.bulletStartPos.position).normalized);
            Rocket.GetComponent<Grenade>().SettingDamage(3,
                GameManager.Instance.player.TargetingHandler.bulletTargetPos - GameManager.Instance.player.TargetingHandler.bulletStartPos.position);
        }
        else
        {
            Debug.Log("유탄이 부족합니다.");
            // 실패음 같은 거 나오면 좋을듯.
        }

    }

    /// <summary>
    /// 'T' 키를 누르면 수리 키트 사용
    /// </summary>
    public void OnUseRepairKitStared(InputAction.CallbackContext context)
    {
        if (playerCondition.CurRepairKitCount > 0)
        {
            SoundManager.Instance.PlayerSFX("RepairKit_Use_SFX", GameManager.Instance.player.transform.position);

            Debug.Log("수리 키트 사용");

            playerCondition.SubRepairKit(1);
            OnRepairKitUsed?.Invoke();

            playerCondition.AddHealth(30);
        }
        else
        {
            Debug.Log("수리 키트가 부족합니다.");
        }
    }
}
