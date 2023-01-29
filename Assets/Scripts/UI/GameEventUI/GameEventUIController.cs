/* =======================================================
 *  Unity版本：2021.3.16f1c1

 *  作 者：红豆
 *  主要功能：游戏事件的UI显示

 *  创建时间：2023-01-29 16:03:36
 *  版 本：1.0
 * =======================================================*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameEventUIController : MonoBehaviour
{
    public TextMeshProUGUI header;//事件标题文本
    public TextMeshProUGUI mainText;//主要文本
    public Button[] options;//事件选项按钮

    private Option[] currentOptions;//储存当前事件的选项

    private void OnEnable()
    {
        EventHandler.GameEventUI += OnGameEventUI;
    }
    private void OnDisable()
    {
        EventHandler.GameEventUI -= OnGameEventUI;
    }

    private void OnGameEventUI(GameEventDetails gameEventDetails)
    {
        header.text = gameEventDetails.eventName;
        mainText.text = gameEventDetails.description;

        if (gameEventDetails.option.Length <= 4)
            for (int i = 0; i < gameEventDetails.option.Length; i++)
            {
                options[i].gameObject.SetActive(true);
                options[i].GetComponentInChildren<TextMeshProUGUI>().text = gameEventDetails.option[i].optionText;
                currentOptions = gameEventDetails.option;
            }
    }
    /// <summary>
    /// 每个按钮效果
    /// </summary>
    /// <param name="optionType">选项类型</param>
    public void ButtonOption(int buttonIndex)
    {
        //TODO:每个选项的功能，效果，文本
        if (currentOptions[buttonIndex].optionType == OptionType.力量选项)
        {
            //力量判断
            //mainText = 成功或失败文本
        }
        mainText.text = "事件结束文本";
        for (int i = 0; i < 4; i++)
        {
            options[i].gameObject.SetActive(false);
        }
    }
}
