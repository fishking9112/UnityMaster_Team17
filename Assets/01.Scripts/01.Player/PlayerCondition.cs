using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    [SerializeField] private int _curHealth;
    public int CurHealth { get => _curHealth; private set => _curHealth = value; }

    [SerializeField] private int _maxHealth = 100;
    public int MaxHealth { get => _maxHealth; private set => _maxHealth = value; }

    [SerializeField] private int _curDashGauge;
    public int CurDashGauge { get => _curDashGauge; private set => _curDashGauge = value; }

    [SerializeField] private int _maxDashGauge;
    public int MaxDashGauge { get => _maxDashGauge; private set => _maxDashGauge = value; }

    [SerializeField] private int _curBulletCount;
    public int CurBulletCount { get => _curBulletCount; private set => _curBulletCount = value; }

    [SerializeField] private int _maxBulletCount = 30;
    public int MaxBulletCount { get => _maxBulletCount; private set => _maxBulletCount = value; }

    [SerializeField] private int _curMagazineCount;
    public int CurMagazineCount { get => _curMagazineCount; private set => _curMagazineCount = value; }

    [SerializeField] private int _maxMagazineCount = 8;
    public int MaxMagazineCount { get => _maxMagazineCount; private set => _maxMagazineCount = value; }

    [SerializeField] private int _curGrenadeCount;
    public int CurGrenadeCount { get => _curGrenadeCount; private set => _curGrenadeCount = value; }

    [SerializeField] private int _maxGrenadeCount = 5;
    public int MaxGrenadeCount { get => _maxGrenadeCount; private set => _maxGrenadeCount = value; }

    [SerializeField] private int _curRepairKitCount;
    public int CurRepairKitCount { get => _curRepairKitCount; private set => _curRepairKitCount = value; }

    [SerializeField] private int _maxRepairKitCount = 3;
    public int MaxRepairKitCount { get=>_maxRepairKitCount; private set=> _maxRepairKitCount = value; }

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

        if (temp >= MaxDashGauge)
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
        int temp = CurMagazineCount + amount;

        if (temp >= MaxMagazineCount)
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

        if (temp <= 0)
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

        if (temp <= 0)
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

        if (temp >= MaxGrenadeCount)
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

        if (temp <= 0)
        {
            CurRepairKitCount = 0;
        }
        else
        {
            CurRepairKitCount = temp;
        }
    }
}
