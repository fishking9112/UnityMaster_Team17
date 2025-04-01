public class QuestUseRepairKit : QuestBase
{
    private int _curUseRepairKitCount;

    /// <summary>
    /// 퀘스트 요구사항 초기화 및 이벤트 구독
    /// </summary>
    protected override void QuestInit()
    {
        _curUseRepairKitCount = 0;
        //GameManager.Instance.player.OnRepairKitUsed += UseRepairKitCount;
    }

    /// <summary>
    /// 아이템이 사용되면 바로 퀘스트를 클리어 처리하고 이벤트 구독 취소
    /// </summary>
    protected override void QuestGoal()
    {
        if (questState == QuestState.ONGOING)
        {
            if (_curUseRepairKitCount >= questInfo.requiredUseCount)
            {
                questManager.QuestClear(questInfo.id);
                //GameManager.Instance.player.OnRepairKitUsed -= UseRepairKitCount;
            }
        }
    }

    private void UseRepairKitCount()
    {
        _curUseRepairKitCount++;
    }
}
