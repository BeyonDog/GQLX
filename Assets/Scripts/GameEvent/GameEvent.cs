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
        public bool isEnd = false;//是否结束（是否触发）

        private void Start()
        {
            GetComponent<SpriteRenderer>().sprite = gameEventDetails.sprite;
        }

        private void OnEnable()
        {
            EventHandler.GameEventEnd += OnGameEventEnd;
        }

        private void OnDisable()
        {
            EventHandler.GameEventEnd += OnGameEventEnd;
        }

        private void OnGameEventEnd(GameEventDetails gameEventDetails)
        {
            isEnd = true;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                //TODO:播放动画和音效
            }

        }

    }
}