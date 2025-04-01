using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestUIController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _textQuestDes;
    public TextMeshProUGUI TextQuestDes {  get { return _textQuestDes; } }
    [SerializeField]
    private TextMeshProUGUI _textQuestCount;
    public TextMeshProUGUI TextQuestCout {  get { return _textQuestCount; } }
    [SerializeField]
    private TextMeshProUGUI _textQuestMaxCount;
    public TextMeshProUGUI TextQuestMaxCount { get { return _textQuestMaxCount; } }

}
