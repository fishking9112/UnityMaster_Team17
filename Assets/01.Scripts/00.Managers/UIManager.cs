using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UI 관리하는 스크립트
/// </summary>

public class UIManager : MonoSingleton<UIManager>
{
    [SerializeField]
    public Canvas uiState_Canvas;
    [SerializeField]
    public Canvas uiQuest_Canvas;
    [SerializeField]
    public Canvas uiMinimap_Canvas;
    
    // Start is called before the first frame update
    void Start()
    {
        GameManager gameManager = GameManager.Instance;

        uiState_Canvas = GameObject.Find("Canvas_StateUI").GetComponent<Canvas>();
        uiQuest_Canvas = GameObject.Find("Canvas_Quest").GetComponent<Canvas>();
        uiMinimap_Canvas = GameObject.Find("Canvas_MiniMap").GetComponent<Canvas>();

        //UI 기본 Set
        uiState_Canvas.gameObject.SetActive(true);
        uiMinimap_Canvas.gameObject.SetActive(true);


        //Quest 기본값을 꺼놓고 , 특수 상황에만 켜준다.
        //uiQuest_Canvas.gameObject.SetActive(false);
        //임시로 다 켜고 작업합시다
        uiQuest_Canvas.gameObject.SetActive(true);
    }


    public void AddQuest(QuestInfo questinfo)
    {
        uiQuest_Canvas.GetComponent<QuestController>().AddQuest(questinfo);
    }
}
