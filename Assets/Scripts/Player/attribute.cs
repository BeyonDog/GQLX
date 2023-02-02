using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attribute : MonoBehaviour
{
    private void OnEnable()
    {
        EventHandler.ChangeEvent += OnChangeEvent;
    }
    private void OnDisable()
    {
        EventHandler.ChangeEvent -= OnChangeEvent;
    }

    private void OnChangeEvent(string newEventID, int[] changeAmounts)
    {
        PlayerModel.Instance.playerPower.value += changeAmounts[0];
        PlayerModel.Instance.playerAgile.value += changeAmounts[1];
        PlayerModel.Instance.playerIntelligence.value += changeAmounts[2];
        PlayerModel.Instance.playerLucky.value += changeAmounts[3];
        PlayerModel.Instance.playerHp.value += changeAmounts[4];
        PlayerModel.Instance.playerGoldcoin.value += changeAmounts[5];
    }
}
