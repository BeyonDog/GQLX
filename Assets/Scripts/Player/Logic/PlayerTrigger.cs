/* =======================================================
 *  Unity版本：2021.3.16f1c1
 *  作 者：红豆
 *  主要功能：玩家身上的触发器
 *  创建时间：2023-01-28 16:20:43
 *  版 本：1.0
 * =======================================================*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GQLX.Game.GameEvent;

public class PlayerTrigger : MonoBehaviour
{
    GameEvent currentGameEvent;
    public GameObject gameEventUI;

    private void OnEnable()
    {
        EventHandler.GameEventEnd += OnGameEventEnd;
    }

    private void OnDisable()
    {
        EventHandler.GameEventEnd -= OnGameEventEnd;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
            if (currentGameEvent != null)
                if (currentGameEvent.isEnd == false)
                {
                    gameEventUI.SetActive(true);
                    EventHandler.CallGameEventUI(currentGameEvent.gameEventID);
                }
                else
                {
                    //对已结束事件的触发
                    gameEventUI.SetActive(true);
                    EventHandler.CallGameEventAgain(currentGameEvent.endText);
                }

    }

    private void OnGameEventEnd(string end)
    {
        currentGameEvent.isEnd = true;
        currentGameEvent.endText = end;//只改当前对象的
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "GameEvent")
            currentGameEvent = other.GetComponent<GameEvent>();

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "GameEvent")
            currentGameEvent = null;


    }
}
