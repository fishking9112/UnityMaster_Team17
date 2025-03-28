using UnityEngine;

public class QuestMove : QuestBase
{
    [Space(10)]
    [Header("이동 퀘스트 정보")]
    public float requiredDistance;

    private float _curMovedDistance;

    private Vector3 _startPlayerPosition;
    private Transform _curPlayerTransform;

    protected override void Update()
    {
        base.Update();

        UpdatePlayerMovement();
    }

    /// <summary>
    /// 플레이어의 퀘스트 시작 위치와 현재 위치를 받아옴
    /// </summary>
    protected override void QuestInit()
    {
        // player는 이후에 게임 매니저에서 받아오도록 수정 예정
        _startPlayerPosition = GameObject.Find("Player").transform.position;
        _curPlayerTransform = GameObject.Find("Player").transform;
    }

    /// <summary>
    /// 플레이어가 얼마나 이동했는 지 체크
    /// </summary>
    private void UpdatePlayerMovement()
    {
        if (questState == QuestState.ONGOING)
        {
            _curMovedDistance = Vector3.Distance(_startPlayerPosition, _curPlayerTransform.position);
            Debug.Log(_curMovedDistance);
        }
    }

    /// <summary>
    /// 플레이어의 위치가 퀘스트를 시작했을 때 부터 일정거리 이상 멀어지면 퀘스트 클리어
    /// </summary>
    protected override void QuestGoal()
    {
        if (questState == QuestState.ONGOING)
        {
            if (_curMovedDistance >= requiredDistance)
            {
                questManager.QuestClear(questId);
            }
        }
    }
}
