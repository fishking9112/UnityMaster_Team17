public class QuestUseItem : QuestBase
{
    private bool _isuUseItem;

    //해당 부분에 Player 스크립트에 포함 되어야 함
    //public event Action OnItemUsed;

    //public void UseItem()
    //{
    //    OnItemUsed?.Invoke();
    //}

    /// <summary>
    /// Player에 존재하는 아이템 사용 이벤트에 클리어 목표 구독
    /// </summary>
    protected override void QuestInit()
    {
        _isuUseItem = false;
        // GameManager.Instance.Player.OnItemUsed += UseItemCheck;
    }

    /// <summary>
    /// 아이템이 사용되면 바로 퀘스트를 클리어 처리하고 이벤트 구독 취소
    /// </summary>
    protected override void QuestGoal()
    {
        if(_isuUseItem)
        {
            questManager.QuestClear(questId);
           // GameManager.Instance.Player.OnItemUsed -= QuestGoal;
        }
    }

    private void UseItemCheck()
    {
        _isuUseItem = true;
    }
}
