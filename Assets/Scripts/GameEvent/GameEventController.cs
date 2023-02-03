using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GQLX.Game.GameEvent
{
    public class GameEventController : MonoBehaviour
    {
        // TODO:随机生成算法写在这里

        //测试：=============================
        public EventDetails_SO eventDetails;
        public GameObject eventPrefab;

        Dictionary<string, GameEventDetails> gameEventDict = new Dictionary<string, GameEventDetails>();

        private void Awake()
        {
            foreach (var gameEvent in eventDetails.gameEventDetails)
            {
                gameEventDict.Add(gameEvent.eventID, gameEvent);
            }

            GameObject newEvent = Instantiate(eventPrefab, new Vector3(17, 5, 0), new Quaternion(0, 0, 0, 0), this.transform);

            newEvent.transform.GetChild(0).GetComponent<GameEvent>().gameEventID = gameEventDict["SJ#0101"].eventID;
            newEvent.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = gameEventDict["SJ#0101"].sprite;
        }
        private void OnEnable()
        {
            EventHandler.ChangeEvent += OnChangeEvent;
        }
        private void OnDisable()
        {
            EventHandler.ChangeEvent -= OnChangeEvent;
        }

        private void OnChangeEvent(string newEventID, int[] arg2)
        {
            if (newEventID != string.Empty)
            {
                GameObject newEvent = Instantiate(eventPrefab, new Vector3(10, 5, 0), new Quaternion(0, 0, 0, 0), this.transform);

                newEvent.GetComponentInChildren<GameEventIsFind>().FoundEvent();
                newEvent.GetComponentInChildren<GameEvent>().gameEventID = gameEventDict[newEventID].eventID;
                newEvent.GetComponentInChildren<SpriteRenderer>().sprite = gameEventDict[newEventID].sprite;
                //TODO:生成后播放提示音效
            }
        }

        //===================================
    }
}