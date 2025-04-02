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
        //AddUseGrenadeCallback();
        AddUseRepairKitCallback();
    }

    //private void AddUseGrenadeCallback()
    //{
    //    GameManager.Instance.player.Input.playerActions.Grenade.started += OnUseGrenadeStared;
    //}

    private void AddUseRepairKitCallback()
    {
        GameManager.Instance.player.Input.playerActions.RepairKit.started += OnUseRepairKitStared;
    }

    /// <summary>
    /// 'G' 키를 누르면 유탄 발사
    /// </summary>
    public void OnUseGrenadeStared(InputAction.CallbackContext context)
    {
        if(playerCondition.CurGrenadeCount > 0)
        {
            Debug.Log("유탄 발사");

            playerCondition.SubGrenade(1);
            OnGrenadeUsed?.Invoke();

            // 유탄 발사 
            ShootRocket();
        }
        else
        {
            Debug.Log("유탄이 부족합니다.");
            // 실패음 같은 거 나오면 좋을듯.
        }
    }
    public void ShootRocket()
    {
        //로켓을 왼속에서 발싸
        GameObject Rocket = BulletManager.Instance.SpawnRocket();
        Rocket.transform.position = GameManager.Instance.player.TargetingHandler.bulletStartPos.position;
        Rocket.transform.rotation = Quaternion.LookRotation((GameManager.Instance.player.TargetingHandler.bulletTargetPos - GameManager.Instance.player.TargetingHandler.bulletStartPos.position).normalized);
        Rocket.GetComponent<Grenade>().SettingDamage(3,
            GameManager.Instance.player.TargetingHandler.bulletTargetPos - GameManager.Instance.player.TargetingHandler.bulletStartPos.position);
    }

    /// <summary>
    /// 'T' 키를 누르면 수리 키트 사용
    /// </summary>
    public void OnUseRepairKitStared(InputAction.CallbackContext context)
    {
        if (playerCondition.CurRepairKitCount > 0)
        {
            SoundManager.Instance.PlayerSFX("RepairKit_Use_SFX",GameManager.Instance.player.transform.position);

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
