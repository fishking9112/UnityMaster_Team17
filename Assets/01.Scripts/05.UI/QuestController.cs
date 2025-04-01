using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestController : MonoBehaviour
{
    [SerializeField]
    private GameObject quest;

    [SerializeField]
    private GameObject questPannel;

    private void Start()
    {
        quest = Resources.Load<GameObject>("Quest");

        questPannel = transform.Find("QuestPannel").gameObject;

        /*
         * 퀘스트 프리팹으로 만든거 만들어서
         * 판넬에다가 만들어주기 테스트 해보기 !
         */



    }

    // 퀘스트 보드에 퀘스트 추가하는 함수
    public void AddQuest(QuestInfo questinfo)
    {
        Debug.Log("AddQuest");

        
    }

}
