public class QuestUseRepairKit : QuestBase
{
    /// <summary>
    /// 퀘스트 요구사항 초기화 및 이벤트 구독
    /// </summary>
    protected override void QuestInit()
    {
        questInfo.curCount = 0;
        GameManager.Instance.player.UseItem.OnRepairKitUsed += UseRepairKitCount;
    }

    /// <summary>
    /// 아이템이 사용되면 바로 퀘스트를 클리어 처리하고 이벤트 구독 취소
    /// </summary>
    protected override void QuestGoal()
    {
        if (questInfo.questState == QuestState.ONGOING)
        {
            if (questInfo.curCount >= questInfo.requiredCount)
            {
                questManager.QuestClear(questInfo.id);
                GameManager.Instance.player.UseItem.OnRepairKitUsed -= UseRepairKitCount;
            }
        }
    }

    private void UseRepairKitCount()
    {
        questInfo.curCount++;
    }
}
