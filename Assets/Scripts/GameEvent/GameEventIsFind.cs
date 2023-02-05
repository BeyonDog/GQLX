/* =======================================================
 *  Unity版本：2021.3.16f1c1

 *  作 者：
 *  主要功能：

 *  创建时间：2023-02-05 13:56:06
 *  版 本：1.0
 * =======================================================*/
using System;
// ========================================================
// 脚 本 功 能:每个事件外层的发现范围
// 作 者： 红豆
// 版 本：v 1.0
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GQLX.Game.GameEvent
{
    public class GameEventIsFind : MonoBehaviour
    {
        public GameEvent gameEvent;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                FoundEvent();
            }
        }
        /// <summary>
        /// 发现事件
        /// </summary>
        public void FoundEvent()
        {
            gameEvent.gameObject.SetActive(true);
            gameEvent.isFind = true;
        }
    }

}