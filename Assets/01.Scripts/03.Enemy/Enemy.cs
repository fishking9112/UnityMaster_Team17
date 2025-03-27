using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    None,
    Idle,
    Find,
    Chase,
    Attack
}

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyState NowState;
    public float FindPlayerSight;

    [Header("Scripts")]
    public EnemyFindPlayer enemyFindPlayer;

    EnemyState _enemyState;

    private void Awake()
    {
        enemyFindPlayer = GetComponent<EnemyFindPlayer>();
    }

    private void Start()
    {
        ChangeState(EnemyState.None);
    }

    private void Update()
    {
        if(NowState == EnemyState.None) return;

        if (enemyFindPlayer.IsPlayerInFieldOfView(FindPlayerSight))
        {
            if (enemyFindPlayer.IsPlayerInSight())
            {
                //게임 메니저에 있는 플레이어 위치로 Ai Nav를 통해 State변경
            }
        }
    }

    void ChangeState(EnemyState changeState)
    {
        if (NowState == changeState) return;

        NowState = changeState;

        if (NowState != EnemyState.None)
        {
            StateisnotNone();
        }

        switch (NowState)
        {
            case EnemyState.None:
                StateisNone();
                break;

            case EnemyState.Idle:
                StateisIdle();
                break;

            case EnemyState.Find:
                StateisFind();
                break;

            case EnemyState.Chase:
                StateisChase();
                break;

            case EnemyState.Attack:
                StateisAttack();
                break;
        }
    }

    void StateisNone()
    {
        enemyFindPlayer.enabled = false;
    }

    void StateisnotNone()
    {
        enemyFindPlayer.enabled = true;
    }

    void StateisIdle()
    {
        //애니메이션 idle로
    }
    void StateisFind()
    {
        //애니메이션 idle로
        //?표 띄우기
    }
    void StateisChase()
    {
        //애니메이션 run로
    }
    void StateisAttack()
    {
        //애니메이션 attack로
    }
}
