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
    /// 游戏事件UI
    /// </summary>
    public static event Action<string> GameEventUI;
    /// <summary>
    /// 呼叫游戏事件UI
    /// </summary>
    /// <param name="gameEventDetails">事件ID</param>
    public static void CallGameEventUI(string gameEventID)
    {
        GameEventUI?.Invoke(gameEventID);
    }

    /// <summary>
    /// 游戏事件结束
    /// </summary>
    public static event Action<string, Sprite> GameEventEnd;
    /// <summary>
    /// 呼叫游戏事件结束
    /// </summary>
    /// <param name="endText">事件ID</param>
    public static void CallGameEventEnd(string endText, Sprite endSprite)
    {
        GameEventEnd?.Invoke(endText, endSprite);
    }

    /// <summary>
    /// 结束后事件
    /// </summary>
    public static event Action<string, Sprite> GameEventAgain;
    /// <summary>
    /// 触发结束后事件
    /// </summary>
    /// <param name="endText"></param>
    public static void CallGameEventAgain(string endText, Sprite sprite)
    {
        GameEventAgain?.Invoke(endText, sprite);
    }
    /// <summary>
    /// 事件最终的改变
    /// </summary>
    public static event Action<string, int[]> ChangeEvent;
    /// <summary>
    /// 触发事件最终的改变
    /// </summary>
    /// <param name="newEventID"></param>
    /// <param name="changeAmounts"></param>
    public static void CallChangeEvent(string newEventID, int[] changeAmounts)
    {
        ChangeEvent?.Invoke(newEventID, changeAmounts);
    }

}
