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

public class GameEventUIC : MonoBehaviour
{
    public TextMeshProUGUI header;//事件标题文本
    public Image image;//事件示意图
    public TextMeshProUGUI mainText;//主要文本
    public Button[] options;//事件选项按钮
    public GameObject[] highLights;//高亮列表
    public Button sureButton;//确认按钮
    int buttonIndex;//目前选中的按钮
    public Button exitButton;//退出按钮

    private GameEventDetails currentGED;//当前传入的游戏事件信息

    private Option[] currentOptions;//储存当前事件的选项
    private string[] currentTexts;//储存当前事件的描述文本
    int textIndex = 0;//当前文本页码
    bool isTextend;//文本是否播放完成

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && isTextend == false)
        {
            if (textIndex >= currentTexts.Length - 1)
            {
                DisplayButton();
            }
            else
            {//左键每戳一下，文本往后显示一页
                textIndex++;
                mainText.text = currentTexts[textIndex];
            }
        }
    }

    private void OnEnable()
    {
        EventHandler.GameEventUI += OnGameEventUI;
        EventHandler.GameEventEnd += OnGameEventEnd;
    }
    private void OnDisable()
    {
        EventHandler.GameEventUI -= OnGameEventUI;
        EventHandler.GameEventEnd -= OnGameEventEnd;
    }

    /// <summary>
    /// UI开启后执行
    /// </summary>
    /// <param name="gameEventDetails">事件信息</param>
    private void OnGameEventUI(GameEventDetails gameEventDetails)
    {
        currentGED = gameEventDetails;
        header.text = gameEventDetails.eventName;
        image.sprite = gameEventDetails.image;
        currentTexts = gameEventDetails.description;
        mainText.text = currentTexts[0];
        isTextend = false;//正文播放开始
        textIndex = 0;//页码归零

    }

    /// <summary>
    /// 事件结束后
    /// </summary>
    /// <param name="gameEventDetails"></param>
    private void OnGameEventEnd(GameEventDetails gameEventDetails)
    {
        header.text = string.Empty;
        mainText.text = string.Empty;
        exitButton.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }

    /// <summary>
    /// 循环开启所需按钮并填入文本
    /// </summary>
    void DisplayButton()
    {
        if (currentGED.option.Length <= 4)
            for (int i = 0; i < currentGED.option.Length; i++)
            {
                options[i].gameObject.SetActive(true);
                options[i].GetComponentInChildren<TextMeshProUGUI>().text = currentGED.option[i].optionText;
                currentOptions = currentGED.option;
            }

        isTextend = true;//正文播放结束
    }

    /// <summary>
    /// 点击确认后的操作
    /// </summary>
    /// <param name="optionType">选项类型</param>
    public void ButtonOption()
    {
        //TODO:每个选项的功能，效果，文本
        if (currentOptions[buttonIndex].optionType == OptionType.力量选项)
        {
            //力量判断
            //mainText = 成功或失败文本
            //Call人物属性改变事件
        }
        //循环关闭所有按钮
        for (int i = 0; i < 4; i++)
        {
            options[i].gameObject.SetActive(false);
        }
        exitButton.gameObject.SetActive(true);

        mainText.text = "嗷呜，好舒服~";
    }

    /// <summary>
    /// 按钮点击后的操作
    /// </summary>
    /// <param name="buttonIndex"></param>
    public void ButtonSelect(int index)
    {
        buttonIndex = index;
        foreach (var highLight in highLights)
        {
            highLight.SetActive(false);
        }
        highLights[buttonIndex].SetActive(true);
    }

    public void ExitButton()
    {
        EventHandler.CallGameEventEnd(currentGED);
        exitButton.gameObject.SetActive(false);
    }
}
