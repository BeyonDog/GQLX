using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
// ========================================================
// 脚 本 功 能:事件中心
// 作 者： 红豆
// 版 本：v 1.0
// ========================================================
public static class EventHandler
{
    /// <summary>
    /// 游戏事件
    /// </summary>
    public static event Action<string> GameEvent;
    /// <summary>
    /// 触发游戏事件
    /// </summary>
    /// <param name="gameEventID">事件ID</param>
    public static void CallGameEvent(string gameEventID)
    {
        GameEvent?.Invoke(gameEventID);
    }
}
