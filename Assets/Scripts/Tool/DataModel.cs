using UnityEngine;


// ========================================================
// 脚 本 功 能:数据结构集
// 作 者： 红豆
// 版 本：v 1.0
// ========================================================

/// <summary>
/// 选项类型
/// </summary>
[System.Serializable]
public class GameEventDetails
{
    [Header("事件ID和事件名")]
    public string eventID;
    public string eventName;
    [Header("事件描述")]
    [TextArea]
    public string text;
    [Header("选项")]
    public Option[] option;
}

[System.Serializable]
public struct Option
{
    public OptionType optionType;
    public string optionText;
    [Header("所需属性值")]
    public int attributeValue;
    [Header("胜利文本")]
    public string winText;
    [Header("失败文本")]
    public string deText;
}