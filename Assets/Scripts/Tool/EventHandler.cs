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
    public static event Action<GameEventDetails> GameEvent;
    /// <summary>
    /// 触发游戏事件
    /// </summary>
    /// <param name="gameEventID">事件ID</param>
    public static void CallGameEvent(GameEventDetails gameEventDetails)
    {
        GameEvent?.Invoke(gameEventDetails);
    }

    /// <summary>
    /// 游戏事件结束
    /// </summary>
    public static event Action<GameEventDetails> GameEventEnd;
    /// <summary>
    /// 呼叫游戏事件结束
    /// </summary>
    /// <param name="gameEventID">事件ID</param>
    public static void CallGameEventEnd(GameEventDetails gameEventDetails)
    {
        GameEventEnd?.Invoke(gameEventDetails);
    }

    /// <summary>
    /// 游戏事件UI
    /// </summary>
    public static event Action<GameEventDetails> GameEventUI;
    /// <summary>
    /// 呼叫游戏事件UI
    /// </summary>
    /// <param name="gameEventDetails">事件ID</param>
    public static void CallGameEventUI(GameEventDetails gameEventDetails)
    {
        GameEventUI?.Invoke(gameEventDetails);
    }

}
