using System;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoSingleton<QuestManager>
{
    public QuestData questData;
    private Dictionary<int, QuestBase> _questDictionary;

    public event Action<int> OnQuestCleared; // 퀘스트 클리어 시 발생하는 이벤트(현재 DoorController에서 사용) - 한만진

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
        _questDictionary = new Dictionary<int, QuestBase>();

        for (int i = 0; i < questData.questInfoList.Count; i++)
        {
            QuestInfo info = questData.questInfoList[i];

            GameObject questObject = new GameObject($"Quest{i}");
            TypeAddComponent(questObject, info);
            QuestBase quest = questObject.GetComponent<QuestBase>();
            quest.questInfo = info;
            _questDictionary[info.id] = quest;

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
            case QuestType.USE_GRENADE:
                questObject.AddComponent<QuestUseGrenade>();
                break;
            case QuestType.USE_REPAIRKIT:
                questObject.AddComponent<QuestUseRepairKit>();
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
        SoundManager.Instance.PlayerSFX("Quest_Accept_SFX", GameManager.Instance.player.transform.position);

        QuestBase quest = _questDictionary[id];

        quest.questInfo.questState = QuestState.ONGOING;

        Debug.Log($"{_questDictionary[id].questInfo.name}");
        Debug.Log($"{_questDictionary[id].questInfo.description}");
        Debug.Log("퀘스트 시작");
    }

    /// <summary>
    /// 퀘스트 클리어 시 text를 UI에 출력
    /// </summary>
    public void QuestClear(int id)
    {
        SoundManager.Instance.PlayerSFX("Quest_Clear_SFX", GameManager.Instance.player.transform.position);

        QuestBase quest = _questDictionary[id];

        quest.questInfo.questState = QuestState.CLEAR;

        Debug.Log("퀘스트 완료");

        OnQuestCleared?.Invoke(id); // 퀘스트 클리어 시 이벤트 발생 - 한만진
    }

    /// <summary>
    /// 모든 퀘스트를 진행 전 상태로 리셋
    /// </summary>
    public void QuestReset()
    {
        Debug.Log("퀘스트 리셋");
        for(int i = 0; i < _questDictionary.Count; i++)
        {
            _questDictionary[i].questInfo.questState = QuestState.BEFORE;
        }
    }
}
