using UnityEngine;

public enum QuestState
{
    BEFORE,
    ONGOING,
    CLEAR,
}

public abstract class QuestBase : MonoBehaviour
{
    public QuestInfo questInfo;
    protected QuestManager questManager;

    protected virtual void Start()
    {
        questManager = QuestManager.Instance;
        questInfo.questState = QuestState.BEFORE;
    }

    protected virtual void Update()
    {
        if(questInfo.questState == QuestState.ONGOING)
        {
            QuestGoal();
        }
    }

    /// <summary>
    /// 퀘스트의 목적, 무엇을 해야 완료되는 지
    /// </summary>
    protected abstract void QuestGoal();

    /// <summary>
    /// 퀘스트 초기 설정
    /// </summary>
    protected abstract void QuestInit();

    /// <summary>
    /// 해당 퀘스트의 범위 안에 들어왔을 때, 대상이 플레이어인 경우, 퀘스트 시작
    /// </summary>
    /// <param name="other"> 충돌 대상 </param>
    protected virtual void OnTriggerEnter(Collider other)
    {
        if(questInfo.questState == QuestState.BEFORE)
        {
            if (other.CompareTag("Player"))
            {
                QuestInit();
                UIManager.Instance.AddQuest(questInfo);
                questManager.QuestStart(questInfo.id);
            }
        }
    }
}