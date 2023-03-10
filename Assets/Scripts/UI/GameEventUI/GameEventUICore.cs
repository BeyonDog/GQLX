/* =======================================================
 *  Unity版本：2021.3.16f1c1

 *  作 者：红豆
 *  主要功能：游戏事件的UI控制与核心判断逻辑

 *  创建时间：2023-01-29 16:03:36
 *  版 本：1.0
 * =======================================================*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameEventUICore : MonoBehaviour
{
    public EventDetails_SO gameEventList;
    public ResultEvent_SO resultEventList;
    Dictionary<string, GameEventDetails> gameEventDict = new Dictionary<string, GameEventDetails>();
    Dictionary<string, ResultEvent> resultEventDict = new Dictionary<string, ResultEvent>();

    public Text header;//事件标题文本
    public Image image;//事件示意图
    public Text mainText;//主要文本
    public Button[] options;//事件选项按钮
    public GameObject[] highLights;//高亮列表
    public Button sureButton;//确认按钮
    public Button exitButton;//退出按钮
    int buttonIndex = -1;//目前选中的按钮

    private GameEventDetails currentGED;//当前传入的游戏事件信息

    private Option[] currentOptions;//储存当前事件的选项
    private string[] currentTexts;//储存当前事件的描述文本
    int textIndex = 0;//当前文本页码
    bool isTextend;//文本是否播放完成

    private void Awake()
    {
        //初始化字典
        foreach (var gameEvent in gameEventList.gameEventDetails)
        {
            gameEventDict.Add(gameEvent.eventID, gameEvent);
        }
        foreach (var resultEvent in resultEventList.resultEvents)
        {
            resultEventDict.Add(resultEvent.ID, resultEvent);
        }
    }

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
        EventHandler.GameEventAgain += OnGameEventAgain;
    }
    private void OnDisable()
    {
        EventHandler.GameEventUI -= OnGameEventUI;
        EventHandler.GameEventEnd -= OnGameEventEnd;
        EventHandler.GameEventAgain -= OnGameEventAgain;
    }

    private void OnGameEventAgain(string endHeader, string endText, Sprite endSprite)
    {
        header.text = endHeader;
        image.sprite = endSprite;
        mainText.text = endText;
        exitButton.gameObject.SetActive(true);
    }

    /// <summary>
    /// UI开启后执行
    /// </summary>
    /// <param name="gameEventID">事件信息</param>
    private void OnGameEventUI(string gameEventID)
    {
        currentGED = gameEventDict[gameEventID];
        header.text = currentGED.eventName;
        image.sprite = currentGED.image;
        currentTexts = currentGED.description;
        mainText.text = currentTexts[0];
        isTextend = false;//正文播放开始
        textIndex = 0;//页码归零
    }

    /// <summary>
    /// 事件结束后
    /// </summary>
    /// <param name="endText"></param>
    private void OnGameEventEnd(string endHeader, string endText, Sprite endSprite)
    {
        header.text = string.Empty;
        mainText.text = string.Empty;
        currentGED = null;
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
                options[i].GetComponentInChildren<Text>().text = currentGED.option[i].optionText;
                currentOptions = currentGED.option;
            }
        sureButton.gameObject.SetActive(true);//顺便开启确认按钮
        //这里把确认按钮变灰,且不可用
        sureButton.image.color = Color.gray;
        sureButton.enabled = false;
        isTextend = true;//正文播放结束
    }

    /// <summary>
    /// 点击确认后的操作
    /// </summary>
    /// <param name="optionType">选项类型</param>
    public void ButtonOption()
    {

        //循环关闭所有按钮
        foreach (var option in options)
        {
            option.gameObject.SetActive(false);
        }
        //循环关闭所有高亮
        foreach (var highLight in highLights)
        {
            highLight.SetActive(false);
        }
        exitButton.gameObject.SetActive(true);

        mainText.text = AttrJudge();//属性判断并赋值到文本区

        buttonIndex = -1;//按钮指针置空
        //这里把确认按钮变灰,且不可用
        sureButton.image.color = Color.gray;
        sureButton.enabled = false;
    }

    /// <summary>
    /// 按钮点击后的操作
    /// </summary>
    /// <param name="index">按钮编号</param>
    public void ButtonSelect(int index)
    {
        if (buttonIndex == index)//判断传进来的是否是点击过的按钮编号
        {
            buttonIndex = -1;//重复点击，指针置空
            //把确认按钮变为不可用
            sureButton.image.color = Color.gray;
            sureButton.enabled = false;
        }
        else
        {
            buttonIndex = index;

            foreach (var highLight in highLights)
            {
                highLight.SetActive(false);
            }
            if (buttonIndex >= 0)
                highLights[buttonIndex].SetActive(true);
            //这里把确认按钮变亮
            sureButton.image.color = Color.white;
            sureButton.enabled = true;
        }
    }

    /// <summary>
    /// 点击确认后的属性值判断
    /// </summary>
    /// <returns></returns>
    string AttrJudge()
    {
        int playerAttr = -1;//当前所需判断属性
        int needAttr = -1;//当前考验值
        float odd = 0;
        int lucky = PlayerModel.Instance.playerLucky.value;//当前幸运
        int luckyRate = PlayerModel.Instance.luckyRate;//幸运除率
        Option currentOption = currentGED.option[buttonIndex];
        //获取当前按钮编号所代表的选项,其里面的属性考验值
        if (buttonIndex >= 0)
            needAttr = currentOption.attributeValue;
        //获取玩家当前需要参加考验的属性值
        switch (currentOptions[buttonIndex].optionType)
        {
            case OptionType.力量选项:
                playerAttr = PlayerModel.Instance.playerPower.value;
                break;
            case OptionType.敏捷选项:
                playerAttr = PlayerModel.Instance.playerAgile.value;
                break;
            case OptionType.智力选项:
                playerAttr = PlayerModel.Instance.playerIntelligence.value;
                break;
            case OptionType.幸运选项:
                playerAttr = lucky;
                break;
        }
        //计算成功率
        if (((playerAttr + needAttr) - (lucky / luckyRate)) <= 0)
            odd = 1;
        else
            odd = (float)playerAttr / ((playerAttr + needAttr) - (lucky / luckyRate));
        // Debug.Log(odd);
        //判断是否成功
        ResultEvent resultEvent;
        if (odd >= Random.value)
        {//成功
            resultEvent = resultEventDict[currentOption.winEventID];
            // Debug.Log(resultEvent + "成功");
        }
        else
        {//失败
            resultEvent = resultEventDict[currentOption.deEventID];
            // Debug.Log(resultEvent + "失败");
        }
        //启动结算事件
        EventHandler.CallChangeEvent(resultEvent.generateID, resultEvent.changeAmounts);
        //返回结算文本
        return resultEvent.text;
    }

    /// <summary>
    /// 点击退出按钮后
    /// </summary>
    public void ExitButton()
    {
        //把当前文本和图片作为最终文本传递回事件中心（目前还未做结束图片功能，暂时传原图片）
        EventHandler.CallGameEventEnd(header.text, mainText.text, image.sprite);
        exitButton.gameObject.SetActive(false);
    }
}
