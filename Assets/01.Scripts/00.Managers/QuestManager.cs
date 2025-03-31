using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoSingleton<QuestManager>
{
    public QuestData questData;
    private Dictionary<int, QuestBase> questDictionary;

    protected override void Awake()
    {
        base.Awake();

        InitSpawnQuest();
    }

    /// <summary>
    /// 게임이 실행되면 QuestData를 토대로 맵에 퀘스트 생성
    /// </summary>
    private void InitSpawnQuest()
    {
        questDictionary = new Dictionary<int, QuestBase>();

        for (int i = 0; i < questData.questInfoList.Count; i++)
        {
            QuestInfo info = questData.questInfoList[i];

            GameObject questObject = new GameObject($"Quest{i}");
            TypeAddComponent(questObject, info);
            QuestBase quest = questObject.GetComponent<QuestBase>();
            quest.questInfo = info;
            questDictionary[info.id] = quest;

            questObject.transform.SetParent(this.transform);
            questObject.transform.localPosition = info.position;
            questObject.transform.localScale = info.scale;
            questObject.AddComponent<BoxCollider>();
            questObject.GetComponent<BoxCollider>().isTrigger = true;
        }
    }

    /// <summary>
    /// 타입에 따라 다른 컴포넌트를 추가함
    /// </summary>
    /// <param name="questObject"></param>
    /// <param name="info"></param>
    private void TypeAddComponent(GameObject questObject, QuestInfo info)
    {
        switch (info.type)
        {
            case QuestType.PLAYER_MOVE:
                questObject.AddComponent<QuestMove>();
                break;
            case QuestType.USE_ITEM:
                questObject.AddComponent<QuestUseItem>();
                break;
            case QuestType.KILL_ENEMY:
                questObject.AddComponent<QuestKillEnemy>();
                break;
        }
    }

    /// <summary>
    /// 퀘스트 시작 시 text를 UI에 출력
    /// </summary>
    public void QuestStart(int id)
    {
        QuestBase quest = questDictionary[id];

        quest.questState = QuestState.ONGOING;

        Debug.Log($"{questDictionary[id].questInfo.name}");
        Debug.Log($"{questDictionary[id].questInfo.description}");
        Debug.Log("퀘스트 시작");
    }

    /// <summary>
    /// 퀘스트 클리어 시 text를 UI에 출력
    /// </summary>
    public void QuestClear(int id)
    {
        QuestBase quest = questDictionary[id];

        quest.questState = QuestState.CLEAR;

        Debug.Log("퀘스트 완료");
    }

    /// <summary>
    /// 모든 퀘스트를 진행 전 상태로 리셋
    /// </summary>
    public void QuestReset()
    {
        Debug.Log("퀘스트 리셋");
        for(int i = 0; i < questDictionary.Count; i++)
        {
            questDictionary[i].questState = QuestState.BEFORE;
        }
    }
}
