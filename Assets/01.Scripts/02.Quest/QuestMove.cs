using UnityEngine;

public class QuestMove : QuestBase
{
    private Vector3 _targetPosition;
    private Transform _playerTransform;

    public float clearDistance = 2;

    protected override void Update()
    {
        base.Update();
    }

    /// <summary>
    /// 플레이어의 퀘스트 시작 위치와 현재 위치를 받아옴
    /// </summary>
    protected override void QuestInit()
    {
        _targetPosition = GameObject.Find("QuestMoveTarget").transform.position;
        _playerTransform = GameManager.Instance.player.transform;
    }

    /// <summary>
    /// 플레이어가 타겟 위치에 도착하면 퀘스트 클리어
    /// </summary>
    protected override void QuestGoal()
    {
        if (questInfo.questState == QuestState.ONGOING)
        {
            if ((_targetPosition-_playerTransform.position).magnitude < clearDistance)
            {
                questManager.QuestClear(questInfo.id);
            }
        }
    }
}
