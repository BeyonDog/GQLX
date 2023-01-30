using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject gameEventUI;
    private void OnEnable()
    {
        EventHandler.GameEvent += OnGameEvent;
    }

    private void OnDisable()
    {
        EventHandler.GameEvent -= OnGameEvent;
    }

    private void OnGameEvent(GameEventDetails gameEventDetails)
    {
        gameEventUI.SetActive(true);
        EventHandler.CallGameEventUI(gameEventDetails);
    }
}
