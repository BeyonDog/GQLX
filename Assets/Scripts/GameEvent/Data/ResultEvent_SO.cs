// ========================================================
// 脚 本 功 能:右键生成选项结果事件列表
// 作 者： 红豆
// 版 本：v 1.0
// ========================================================
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ResultEvent_SO", menuName = "SO/ResultEvent")]
public class ResultEvent_SO : ScriptableObject {
    public List<ResultEvent> resultEvents;
}
