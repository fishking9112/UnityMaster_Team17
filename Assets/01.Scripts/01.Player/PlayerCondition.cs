using UnityEngine;



public class PlayerCondition : MonoBehaviour
{
    public int CurHealth { get; private set; }
    public int MaxHealth { get; private set; } = 100;

    public int CurDashGauge { get; private set; }
    public int MaxDashGauge { get; private set; }

    public int CurBulletCount { get; private set; }
    public int MaxBulletCount { get; private set; } = 30;

    public int CurMagazineCount { get; private set; }
    public int MaxMagazineCount { get; private set; } = 8;

    public int CurGrenadeCount { get; private set; }
    public int MaxGrenadeCount { get; private set; } = 5;


    public int CurRepairKitCount { get; private set; }
    public int MaxRepairKitCount { get; private set; } = 3;

    /// <summary>
    /// 체력 회복
    /// </summary>
    /// <param name="amount"> 회복할 양 </param>
    public void AddHealth(int amount)
    {
        int temp = CurHealth + amount;

        if (temp >= MaxHealth)
        {
            CurHealth = MaxHealth;
        }
        else
        {
            CurHealth = temp;
        }
    }

    /// <summary>
    /// 피격
    /// </summary>
    /// <param name="amount"> 데미지 양 </param>
    public void SubHealth(int amount)
    {
        int temp = CurHealth - amount;

        if (temp <= 0)
        {
            CurHealth = 0;
            OnDie();
        }
        else
        {
            CurHealth = temp;
        }
    }

    /// <summary>
    /// 플레이어가 죽었을 때
    /// </summary>
    public void OnDie()
    {
        // 죽었을 때 처리
    }

    /// <summary>
    /// 대쉬 게이지 상승
    /// </summary>
    /// <param name="amount"> 상승시킬 양 </param>
    public void AddDashGauge(int amount)
    {
        int temp = CurDashGauge + amount;

        if(temp >= MaxDashGauge)
        {
            CurDashGauge = MaxDashGauge;
        }
        else
        {
            CurDashGauge = temp;
        }
    }

    /// <summary>
    /// 대쉬 게이지 감소
    /// </summary>
    /// <param name="amount"> 감소시킬 양 </param>
    public void SubDashGauge(int amount)
    {
        int temp = CurDashGauge - amount;

        if (temp <= 0)
        {
            CurDashGauge = 0;
        }
        else
        {
            CurDashGauge = temp;
        }
    }

    /// <summary>
    /// 총알 개수 증가
    /// </summary>
    /// <param name="amount"> 증가 시킬 총알 개수 </param>
    public void AddBullet(int amount)
    {
        int temp = CurBulletCount + amount;

        if (temp >= MaxBulletCount)
        {
            CurBulletCount = MaxDashGauge;
        }
        else
        {
            CurBulletCount = temp;
        }
    }

    /// <summary>
    /// 총알 개수 감소
    /// </summary>
    /// <param name="amount"> 감소시킬 총알 개수 </param>
    public void SubBullet(int amount)
    {
        int temp = CurBulletCount - amount;

        if (temp <= 0)
        {
            CurBulletCount = 0;
        }
        else
        {
            CurBulletCount = temp;
        }
    }

    /// <summary>
    /// 탄창 개수 증가
    /// </summary>
    /// <param name="amount"> 증가시킬 탄창 개수 </param>
    public void AddMagazine(int amount)
    {
        int temp = CurMagazineCount - amount;

        if(temp >= MaxMagazineCount)
        {
            CurMagazineCount = MaxMagazineCount;
        }
        else
        {
            CurMagazineCount = temp;
        }
    }

    /// <summary>
    /// 탄창 개수 감소
    /// </summary>
    /// <param name="amount"> 감소시킬 탄창 개수 </param>
    public void SubMagazine(int amount)
    {
        int temp = CurMagazineCount - amount;

        if(temp <= 0)
        {
            CurMagazineCount = 0;
        }
        else
        {
            CurMagazineCount = temp;
        }
    }

    /// <summary>
    /// 수류탄 개수 증가
    /// </summary>
    /// <param name="amount"> 증가시킬 수류탄 개수 </param>
    public void AddGrenade(int amount)
    {
        int temp = CurGrenadeCount + amount;

        if (temp >= MaxGrenadeCount)
        {
            CurGrenadeCount = MaxGrenadeCount;
        }
        else
        {
            CurGrenadeCount = temp;
        }
    }

    /// <summary>
    /// 수류탄 개수 감소
    /// </summary>
    /// <param name="amount"> 감소시킬 수류탄 개수 </param>
    public void SubGrenade(int amount)
    {
        int temp = CurGrenadeCount - amount;

        if(temp <= 0)
        {
            CurGrenadeCount = 0;
        }
        else
        {
            CurGrenadeCount = temp;
        }
    }


    /// <summary>
    /// 수리 키트 개수 증가
    /// </summary>
    /// <param name="amount"> 증가시킬 수리 키트 개수 </param>
    public void AddRepairKit(int amount)
    {
        int temp = CurRepairKitCount + amount;

        if(temp >= MaxGrenadeCount)
        {
            CurRepairKitCount = MaxRepairKitCount;
        }
        else
        {
            CurRepairKitCount = temp;
        }
    }

    /// <summary>
    /// 수리 키트 개수 감소
    /// </summary>
    /// <param name="amount"> 감소시킬 수리 키트 개수 </param>
    public void SubRepairKit(int amount)
    {
        int temp = CurRepairKitCount + amount;

        if(temp <= 0)
        {
            CurRepairKitCount = 0;
        }
        else
        {
            CurRepairKitCount = temp;
        }
    }
}
