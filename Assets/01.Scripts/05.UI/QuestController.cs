using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestController : MonoBehaviour
{
    [SerializeField]
    private GameObject questUI;

    [SerializeField]
    private GameObject questPannel;

    private void Start()
    {
        //Resources 폴더를 사용 안해서 패스 !
        //quest = Resources.Load<GameObject>("Quest");

        questPannel = transform.Find("QuestPannel").gameObject;

        /*
         * 퀘스트 프리팹으로 만든거 만들어서
         * 판넬에다가 만들어주기 테스트 해보기 !
         */



    }

    // 퀘스트 보드에 퀘스트 추가하는 함수
    public void AddQuest(QuestInfo questinfo)
    {
        //Quest Pannel 에 Quest 추가
        //GameObject newQuestUI = new GameObject($"QuestUI");
        if(questPannel != null)
        {
            if (questUI != null)
            {
                Debug.Log($"AddQuest : + {questinfo.name}");
                GameObject newQuestUI = GameObject.Instantiate(questUI, questPannel.transform);
                QuestUIController questUIController = newQuestUI.GetComponent<QuestUIController>();
                
                switch(questinfo.type)
                {
                    case QuestType.PLAYER_MOVE:
                        questUIController.TextQuestDes.text = questinfo.description;
                        break;
                    case QuestType.USE_REPAIRKIT:
                        questUIController.TextQuestDes.text = questinfo.description;

                        questUIController.TextQuestCout.gameObject.SetActive(true);
                        questUIController.TextQuestMaxCount.gameObject.SetActive(true);

                        questUIController.TextQuestCout.text = questinfo.curCount.ToString();
                        questUIController.TextQuestMaxCount.text = questinfo.requiredCount.ToString();
                        break;
                    case QuestType.USE_GRENADE:
                        questUIController.TextQuestDes.text = questinfo.description;

                        questUIController.TextQuestCout.gameObject.SetActive(true);
                        questUIController.TextQuestMaxCount.gameObject.SetActive(true);

                        questUIController.TextQuestCout.text = questinfo.curCount.ToString();
                        questUIController.TextQuestMaxCount.text = questinfo.requiredCount.ToString();
                        break;
                    case QuestType.KILL_ENEMY:
                        questUIController.TextQuestDes.text = questinfo.description;

                        questUIController.TextQuestCout.gameObject.SetActive(true);
                        questUIController.TextQuestMaxCount.gameObject.SetActive(true);

                        questUIController.TextQuestCout.text = questinfo.curCount.ToString();
                        questUIController.TextQuestMaxCount.text = questinfo.requiredCount.ToString();
                        break;
                }
                
            }
            else
            {
                Debug.LogWarning("questUI_Prefab is null !");
            }
        }
        else
        {
            Debug.LogWarning("QuestPannel is null !");
        }
    }

    private void Update()
    {
        //test
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject newQuestUI = GameObject.Instantiate(questUI, questPannel.transform);
        }
    }
}
