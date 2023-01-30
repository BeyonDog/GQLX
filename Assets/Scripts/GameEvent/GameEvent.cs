using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// ========================================================
// 脚 本 功 能:随机事件脚本
// 作 者： 红豆
// 版 本：v 1.0
// ========================================================
namespace GQLX.Game.GameEvent
{
    public class GameEvent : MonoBehaviour
    {
        public GameEventDetails gameEventDetails;
        /// <summary>
        /// 判断该事件是否结束
        /// </summary>
        private bool isFind = false;//是否已发现
        private bool isEnd = false;//是否结束（是否触发）

        private void OnEnable()
        {
            EventHandler.GameEvent += OnGameEvent;
            EventHandler.GameEventEnd += OnGameEventEnd;
        }

        private void OnDisable()
        {
            EventHandler.GameEvent -= OnGameEvent;
            EventHandler.GameEventEnd += OnGameEventEnd;
        }

        private void OnGameEventEnd(GameEventDetails gameEventDetails)
        {
            isEnd = true;
        }

        /// <summary>
        /// 触发事件时调用
        /// </summary>
        /// <param name="gameEventID">事件的ID</param>
        private void OnGameEvent(GameEventDetails gameEventDetails)
        {
            //触发事件时调用
        }

    }
}