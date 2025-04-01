using UnityEngine;

public class QuestKillEnemy : QuestBase
{
    private int _curKillEnemyCount;

    /// <summary>
    /// 퀘스트 요구치 초기화 및 이벤트 구독
    /// </summary>
    protected override void QuestInit()
    {
        _curKillEnemyCount = 0;
        EnemyManager.Instance.OnDie += KillEnemyCount;
    }

    /// <summary>
    /// 요구 처치 마리수를 채우면 퀘스트를 클리어 처리하고 이벤트 구독 취소
    /// </summary>
    protected override void QuestGoal()
    {
        if(questState == QuestState.ONGOING)
        {
            if(_curKillEnemyCount >= questInfo.requiredKillEnemyCount)
            {
                questManager.QuestClear(questInfo.id);
                EnemyManager.Instance.OnDie -= KillEnemyCount;
            }
        }
    }

    private void KillEnemyCount()
    {
        _curKillEnemyCount++;
    }
}
