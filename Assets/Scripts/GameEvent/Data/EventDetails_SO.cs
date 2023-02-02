using System.Collections.Generic;
using UnityEngine;
// ========================================================
// 脚 本 功 能:右键生成游戏事件列表
// 作 者： 红豆
// 版 本：v 1.0
// ========================================================
[CreateAssetMenu(fileName = "EventDetails_SO", menuName = "SO/EventDetails")]
public class EventDetails_SO : ScriptableObject
{
    public List<GameEventDetails> gameEventDetails;
}

