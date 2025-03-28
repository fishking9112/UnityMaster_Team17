using UnityEngine;

public class QuestKillEnemy : QuestBase
{
    [Space(10)]
    [Header("적 처치 퀘스트 정보")]
    public int requiredKillEnemyCount;

    private int _curKillEnemyCount;

    //해당 부분이 EnemyManager 같은 적 처치에 관련된 스크립트에 포함 되어야 함
    //public event Action OnDie;

    //public void Die()
    //{
    //    OnDie?.Invoke();
    //}

    public TestScript test;

    /// <summary>
    /// 퀘스트 요구치 초기화 및 이벤트 구독
    /// </summary>
    protected override void QuestInit()
    {
        _curKillEnemyCount = 0;
        // EnemyManager.Instance.OnDie += KillEnemy;

        test.OnDie += KillEnemy;
    }

    /// <summary>
    /// 요구 처치 마리수를 채우면 퀘스트를 클리어 처리하고 이벤트 구독 취소
    /// </summary>
    protected override void QuestGoal()
    {
        if(questState == QuestState.ONGOING)
        {
            if(_curKillEnemyCount >= requiredKillEnemyCount)
            {
                questManager.QuestClear(questId);
                // EnemyManager.Instance.OnDie -= KillEnemy;

                test.OnDie -= KillEnemy;
            }
        }
    }

    private void KillEnemy()
    {
        _curKillEnemyCount++;
    }
}
