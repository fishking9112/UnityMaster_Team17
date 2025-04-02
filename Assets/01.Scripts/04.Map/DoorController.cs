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

    private Dictionary<int, List<Door>> doorDict = new();

    private void Awake()
    {
        if (doors.Length != requiredQuestIDs.Length)
        {
            Debug.LogError("문의 개수와 퀘스트 ID의 개수가 일치하지 않습니다.");
            return;
        }
        // 퀘스트 ID별로 여러 개의 문을 리스트로 관리
        for (int i = 0; i < requiredQuestIDs.Length; i++)
        {
            if (!doorDict.ContainsKey(requiredQuestIDs[i]))
            {
                doorDict[requiredQuestIDs[i]] = new List<Door>();
            }
            doorDict[requiredQuestIDs[i]].Add(doors[i]);
        }
    }

    private void Start()
    {
        QuestManager.Instance.OnQuestCleared += OpenDoorByQuest;
    }

    // 퀘스트 ID를 받아서 해당 퀘스트 ID가 requiredQuestIDs에 있는지 확인하고 있으면 해당 인덱스의 문을 열어줌.
    private void OpenDoorByQuest(int questID)
    {
        if (doorDict.TryGetValue(questID, out List<Door> doorList))
        {
            foreach (var door in doorList)
            {
                door.OpenDoor(); // 해당 퀘스트 ID에 대응하는 모든 문을 연다.
            }
        }
    }
}
