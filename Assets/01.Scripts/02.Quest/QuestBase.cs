using UnityEngine;

public enum QuestState
{
    BEFORE,
    ONGOING,
    CLEAR,
}

public abstract class QuestBase : MonoBehaviour
{
    [Header("공통 퀘스트 정보")]
    public string questName;
    public string questDescription;

    protected QuestState questState = QuestState.BEFORE;

    /// <summary>
    /// 퀘스트 시작 시 text를 UI에 출력
    /// </summary>
    private void QuestStart()
    {
        Debug.Log("퀘스트 시작");
    }

    /// <summary>
    /// 퀘스트의 목적, 무엇을 해야 완료되는 지
    /// </summary>
    public abstract void QuestGoal();

    /// <summary>
    /// 퀘스트 클리어, 퀘스트에 따라 보상을 다르게 줄 수 있으므로 virtual로 구현
    /// </summary>
    public virtual void QuestClear()
    {
        questState = QuestState.CLEAR;

        Debug.Log("퀘스트 완료");
        // 퀘스트 완료 관련 text를 UI에 출력
    }

    /// <summary>
    /// 해당 퀘스트의 범위 안에 들어왔을 때, 대상이 플레이어인 경우, 퀘스트 시작
    /// </summary>
    /// <param name="other"> 충돌 대상 </param>
    protected virtual void OnTriggerEnter(Collider other)
    {
        if(questState == QuestState.BEFORE)
        {
            if (other.CompareTag("Player"))
            {
                questState = QuestState.ONGOING;
                QuestStart();
            }
        }
    }
}
