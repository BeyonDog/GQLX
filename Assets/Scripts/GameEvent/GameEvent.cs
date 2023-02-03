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
        public string gameEventID;
        public string endText;
        public Sprite endSprite;

        /// <summary>
        /// 判断该事件是否已被找到
        /// </summary>
        public bool isFind = false;
        /// <summary>
        /// 是否结束（是否触发）
        /// </summary>
        public bool isEnd = false;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                //TODO:播放动画和音效
            }

        }

    }
}