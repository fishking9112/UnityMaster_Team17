using GoogleSheetsToUnity;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public struct ChatInfo
{
    public int id;
    public string content;
}

[CreateAssetMenu(fileName = "ChatData",menuName ="Scriptable Object/New ChatData")]
public class ChatData : SheetDataReaderBase
{
    public List<ChatInfo> chatInfoList = new List<ChatInfo>();

    private ChatInfo _chatInfo;

    public void UpdateStats(List<GSTU_Cell> list)
    {
        _chatInfo = new ChatInfo();

        foreach (var cell in list)
        {
            switch (cell.columnId)
            {
                case "id":
                    _chatInfo.id = int.Parse(cell.value);
                    break;
                case "content":
                    _chatInfo.content = cell.value;
                    break;
            }
        }
        chatInfoList.Add(_chatInfo);
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(ChatData))]
public class DataReaderEditor : Editor
{
    ChatData data;

    private void OnEnable()
    {
        data = (ChatData)target;
    }

    /// <summary>
    /// 커스텀 에디터 버튼. 누르면 데이터를 읽어옴
    /// </summary>
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GUILayout.Space(20);

        if (GUILayout.Button("구글 시트 데이터 읽어오기"))
        {
            ReadSheet(UpdateData);
            data.chatInfoList.Clear();
        }
    }

    /// <summary>
    /// 구글 시트의 데이터를 읽어옴
    /// </summary>
    /// <param name="callback"> 데이터를 읽어오는 함수 </param>
    /// <param name="mergedcells"> 병합된 셀을 고려할 것인지 </param>
    private void ReadSheet(UnityAction<GstuSpreadSheet> callback, bool mergedcells = false)
    {
        SpreadsheetManager.Read(new GSTU_Search(data.sheetURL, data.sheetName), callback, mergedcells);
    }

    /// <summary>
    /// 지정한 시작열부터 끝열까지의 데이터를 전부 가져옴
    /// </summary>
    /// <param name="sheet"> 구글 시트의 데이터 </param>
    private void UpdateData(GstuSpreadSheet sheet)
    {
        for (int i = data.startRowIndex; i <= data.endRowIndex; ++i)
        {
            data.UpdateStats(sheet.rows[i]);
        }
        EditorUtility.SetDirty(target);
    }
}
#endif