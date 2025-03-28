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

    protected override void QuestInit()
    {
        _curKillEnemyCount = 0;
        // EnemyManager.Instance.OnDie += KillEnemy;

        test.OnDie += KillEnemy;
    }

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
