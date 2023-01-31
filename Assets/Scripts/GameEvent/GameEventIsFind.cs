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
        public GameObject gameEvent;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                gameEvent.SetActive(true);
            }
        }
    }
}