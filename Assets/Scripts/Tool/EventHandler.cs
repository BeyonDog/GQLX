using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class EventHandler
{
    /// <summary>
    /// 游戏事件
    /// </summary>
    public static event Action<int> GameEvent;
    /// <summary>
    /// 触发游戏事件
    /// </summary>
    /// <param name="gameEventID">事件ID</param>
    public static void CallGameEvent(int gameEventID)
    {
        GameEvent?.Invoke(gameEventID);
    }
}
