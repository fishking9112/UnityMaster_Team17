using UnityEngine;

public class QuestMove : QuestBase
{
    [Space(10)]
    [Header("이동 퀘스트 정보")]
    public float requiredDistance;

    private float _curMovedDistance;

    private Vector3 _startPlayerPosition;
    private Transform _curPlayerTransform;

    private void Start()
    {
        _curPlayerTransform = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        UpdatePlayerMovement();

        if(questState == QuestState.ONGOING)
        {
            QuestGoal();
        }
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
    public override void QuestGoal()
    {
        if(_curMovedDistance >= requiredDistance)
        {
            QuestClear();
        }
    }

    /// <summary>
    /// 퀘스트 시작 시 플레이어의 위치를 받아옴
    /// </summary>
    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        _startPlayerPosition = other.transform.position;
    }
}
