using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class QuestUIController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textQuestDes;
    public TextMeshProUGUI TextQuestDes {  get { return textQuestDes; } }
    [SerializeField]
    private TextMeshProUGUI textQuestCount;
    public TextMeshProUGUI TextQuestCount {  get { return textQuestCount; } }
    [SerializeField]
    private TextMeshProUGUI textQuestMaxCount;
    public TextMeshProUGUI TextQuestMaxCount { get { return textQuestMaxCount; } }

    public QuestInfo curInfo;
    public int questID;

    private void Update()
    {
        CheckCount();
        CheckClear();
    }

    private void CheckCount()
    {
        if(curInfo.type == QuestType.PLAYER_MOVE)
        {
            //언젠간 뭐가 추가 되겠지
        }
        else
        {
            TextQuestCount.text = curInfo.curCount.ToString();
        }
    }

    private void CheckClear()
    {
        if(curInfo.questState == QuestState.ONGOING)
        {

            TextQuestDes.color = Color.white;
            TextQuestCount.color = Color.white;
            TextQuestMaxCount.color = Color.white;
        }
        else if (curInfo.questState == QuestState.CLEAR)
        {

            TextQuestDes.color = Color.gray;
            TextQuestCount.color = Color.gray;
            TextQuestMaxCount.color = Color.gray;
        }

    }

}
