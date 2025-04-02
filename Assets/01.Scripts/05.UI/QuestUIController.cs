using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    public void ClearQuest()
    {
        TextQuestDes.color = Color.gray;
        TextQuestCount.color = Color.gray;
        TextQuestMaxCount.color = Color.gray;

    }

}
