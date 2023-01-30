using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GQLX.Game.GameEvent
{
    public class GameEventController : MonoBehaviour
    {
        // TODO:随机生成算法写在这里

        //测试：----------------
        public GameEvent gameEvent;
        public EventDetails_SO eventDetails;
        private void Start()
        {
            gameEvent.gameEventDetails = eventDetails.gameEventDetails[0];
        }
        //----------------------
    }
}