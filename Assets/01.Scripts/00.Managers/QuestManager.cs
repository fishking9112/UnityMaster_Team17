using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoSingleton<QuestManager>
{
    public QuestBase[] questArr;
    private Dictionary<int, QuestBase> questDictionary;

    private void Start()
    {
        questArr = GetComponentsInChildren<QuestBase>();
        questDictionary = new Dictionary<int, QuestBase>();

        for(int i = 0; i < questArr.Length; i++)
        {
            questDictionary[i] = questArr[i];
        }

    }

    /// <summary>
    /// 퀘스트 시작 시 text를 UI에 출력
    /// </summary>
    public void QuestStart(int id)
    {
        QuestBase quest = questDictionary[id];

        quest.questState = QuestState.ONGOING;

        Debug.Log($"{questDictionary[id].questName}");
        Debug.Log($"{questDictionary[id].questDescription}");
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
        for(int i = 0; i < questDictionary.Count; i++)
        {
            questDictionary[i].questState = QuestState.BEFORE;
        }
    }
}
