using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameEvent : MonoBehaviour
{
    public TextMeshProUGUI tmpUGUI;
    public int gameEventID;
    /// <summary>
    /// 文本
    /// </summary>
    [TextArea]
    public string text;
    /// <summary>
    /// 结束后文本
    /// </summary>
    [TextArea]
    public string textEnd;
    /// <summary>
    /// 判断该事件是否结束
    /// </summary>
    private bool isEnd = false;
    private void OnEnable()
    {
        EventHandler.GameEvent += OnGameEvent;
    }

    private void OnDisable()
    {
        EventHandler.GameEvent -= OnGameEvent;
    }
    /// <summary>
    /// 人物移动触发事件时调用
    /// </summary>
    /// <param name="gameEventID">事件的ID</param>
    private void OnGameEvent(int gameEventID)
    {
        if (isEnd == false)
        {
            tmpUGUI.text = text;
            isEnd = true;
        }
        else
        {
            tmpUGUI.text = textEnd;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
            EventHandler.CallGameEvent(gameEventID);
    }
}
