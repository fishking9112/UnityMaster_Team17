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
    public TextMeshProUGUI TextQuestCout {  get { return textQuestCount; } }
    [SerializeField]
    private TextMeshProUGUI textQuestMaxCount;
    public TextMeshProUGUI TextQuestMaxCount { get { return textQuestMaxCount; } }

}
