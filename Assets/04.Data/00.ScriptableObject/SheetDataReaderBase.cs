using UnityEngine;

public class SheetDataReaderBase : ScriptableObject
{
    [Header("Sheet URL")]
    public string sheetURL;

    [Header("Sheet Name")]
    public string sheetName;

    [Header("Start Row Index")]
    public int startRowIndex;

    [Header("End Row Index")]
    public int endRowIndex;
}