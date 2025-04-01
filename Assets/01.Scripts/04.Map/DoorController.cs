using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DoorController : MonoBehaviour
{
    // doors의 개수만큼 requiredQuestIDs를 설정해주어야 함.
    // requiredQuestIDs의 각 인덱스에 해당하는 퀘스트 ID가 완료되면 해당 인덱스의 (doors)문이 열림.
    public Door[] doors;
    public int[] requiredQuestIDs;

    private Dictionary<int, Door> doorDict = new();

    private void Awake()
    {
        if(doors.Length != requiredQuestIDs.Length)
        {
            Debug.LogError("문의 개수와 퀘스트 ID의 개수가 일치하지 않습니다.");
            return;
        }

        for (int i = 0; i < requiredQuestIDs.Length; i++)
        {
            doorDict[requiredQuestIDs[i]] = doors[i];     
        }
    }

    private void Start()
    {
        QuestManager.Instance.OnQuestCleared += OpenDoorByQuest;
    }

    // 퀘스트 ID를 받아서 해당 퀘스트 ID가 requiredQuestIDs에 있는지 확인하고 있으면 해당 인덱스의 문을 열어줌.
    private void OpenDoorByQuest(int questID)
    {
        if (doorDict.TryGetValue(questID, out Door door))
        {
            door.OpenDoor();
        }
    }
}
