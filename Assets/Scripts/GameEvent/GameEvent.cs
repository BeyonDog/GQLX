using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// ========================================================
// 脚 本 功 能:事件预制体脚本
// 作 者： 红豆
// 版 本：v 1.0
// ========================================================
public class GameEvent : MonoBehaviour
{
    public GameEventDetails gameEventDetails;
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
    private void OnGameEvent(string gameEventID)
    {
        if (isEnd == false)
        {
            EventHandler.CallGameEventUI(gameEventDetails);
            isEnd = true;
        }
        else
        {
            //继续显示结束的文本
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
            EventHandler.CallGameEvent(gameEventDetails.eventID);
    }
}
