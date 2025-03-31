using GoogleSheetsToUnity;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Events;
using System;

public enum QuestType
{
    PLAYER_MOVE,
    USE_ITEM,
    KILL_ENEMY,
}

[Serializable]
public struct QuestInfo
{
    public int id;
    public string name;
    public string description;
    public Vector3 position;
    public Vector3 scale;
    public QuestType type;

    // PLAYER_MOVE type일 때 사용
    public float requiredDistance;

    // KILL_ENEMY type일 때 사용
    public int requiredKillEnemyCount;
}

[CreateAssetMenu(fileName = "QuestData", menuName = "Scriptable Object/New QuestData")]
public class QuestData : SheetDataReaderBase
{
    public List<QuestInfo> questInfoList = new List<QuestInfo>();

    QuestInfo questInfo;

    public void UpdateStats(List<GSTU_Cell> list)
    {
        questInfo = new QuestInfo();

        foreach (var cell in list)
        {
            switch (cell.columnId)
            {
                case "id":
                    questInfo.id = int.Parse(cell.value);
                    break;
                case "name":
                    questInfo.name = cell.value;
                    break;
                case "description":
                    questInfo.description = cell.value;
                    break;
                case "posX":
                    questInfo.position.x = float.Parse(cell.value);
                    break;
                case "posY":
                    questInfo.position.y = float.Parse(cell.value);
                    break;
                case "posZ":
                    questInfo.position.z = float.Parse(cell.value);
                    break;
                case "scaleX":
                    questInfo.scale.x = float.Parse(cell.value);
                    break;
                case "scaleY":
                    questInfo.scale.y = float.Parse(cell.value);
                    break;
                case "scaleZ":
                    questInfo.scale.z = float.Parse(cell.value);
                    break;
                case "type":
                    questInfo.type = (QuestType)Enum.Parse(typeof(QuestType), cell.value);
                    break;
                case "requiredDistance":
                    if(questInfo.type == QuestType.PLAYER_MOVE)
                    {
                        questInfo.requiredDistance = float.Parse(cell.value);
                    }
                    break;
                case "requiredKillEnemyCount":
                    if(questInfo.type == QuestType.KILL_ENEMY)
                    {
                        questInfo.requiredKillEnemyCount = int.Parse(cell.value);
                    }
                    break;
            }
        }
        questInfoList.Add(questInfo);
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(QuestData))]
    public class QuestDataReaderEditor : Editor
    {
        QuestData data;

        private void OnEnable()
        {
            data = (QuestData)target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUILayout.Space(20);

            if (GUILayout.Button("구글 시트 데이터 읽어오기"))
            {
                ReadSheet(UpdateData);
                data.questInfoList.Clear();
            }
        }

        private void ReadSheet(UnityAction<GstuSpreadSheet> callback, bool mergedcells = false)
        {
            SpreadsheetManager.Read(new GSTU_Search(data.sheetURL, data.sheetName), callback, mergedcells);
        }

        private void UpdateData(GstuSpreadSheet sheet)
        {
            for (int i = data.startRowIndex; i <= data.endRowIndex; ++i)
            {
                data.UpdateStats(sheet.rows[i]);
            }
            EditorUtility.SetDirty(target);
        }
    }
}
#endif