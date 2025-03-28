public class QuestUseItem : QuestBase
{
    private bool _isuUseItem;

    //해당 부분이 Player 스크립트에 포함 되어야 함
    //public event Action OnItemUsed;

    //public void UseItem()
    //{
    //    OnItemUsed?.Invoke();
    //}

    public TestScript test;

    /// <summary>
    /// 퀘스트 요구사항 초기화 및 이벤트 구독
    /// </summary>
    protected override void QuestInit()
    {
        _isuUseItem = false;
        // GameManager.Instance.Player.OnItemUsed += UseItemCheck;

        test.OnItemUsed += UseItemCheck;
    }

    /// <summary>
    /// 아이템이 사용되면 바로 퀘스트를 클리어 처리하고 이벤트 구독 취소
    /// </summary>
    protected override void QuestGoal()
    {
        if(questState == QuestState.ONGOING)
        {
            if (_isuUseItem)
            {
                questManager.QuestClear(questInfo.id);
                // GameManager.Instance.Player.OnItemUsed -= QuestGoal;

                test.OnItemUsed -= UseItemCheck;
            }
        }
    }

    private void UseItemCheck()
    {
        _isuUseItem = true;
    }
}
