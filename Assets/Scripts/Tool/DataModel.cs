using System.Data;
using UnityEngine;
using UnityEngine.UI;


// ========================================================
// 脚 本 功 能:数据结构集
// 作 者： 红豆
// 版 本：v 1.0
// ========================================================

/// <summary>
/// 事件数据
/// </summary>
[System.Serializable]
public class GameEventDetails
{
    [Header("事件ID和事件名")]
    public string eventID;
    public string eventName;
    [Header("事件描述")]
    public GameEventType gameEventType;
    [TextArea]
    public string[] description;
    [Header("材质和图片")]
    public Sprite sprite;//地图上图片
    public Sprite image;//UI上图片
    [Header("选项")]
    public Option[] option;
}

/// <summary>
/// 事件内选项
/// </summary>
[System.Serializable]
public struct Option
{
    public OptionType optionType;
    public string optionText;
    [Header("所需属性值")]
    public int attributeValue;
    [Header("胜利文本与事件")]
    public string winText;
    public string winEventID;
    [Header("失败文本与事件")]
    public string deText;
    public string deEventID;
}

/// <summary>
/// 结算事件
/// </summary>
[System.Serializable]
public struct ResultEvent
{
    [Header("触发ID")]
    public string ID;
    [Header("文本备注")]
    public string text;
    [Header("触发类型")]
    public int type;
    [Header("产生事件")]
    public string generateID;
    [Header("完成事件")]
    public string compID;
    [Header("数值类型")]
    public int[] amountType;
    [Header("变化值(力，敏，智，幸，血，金币)")]
    public int[] changeAmounts;
    [Header("解锁图鉴")]
    public string guideID;
    [Header("图片")]
    public Sprite sprite;
}