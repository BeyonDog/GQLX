 /* =======================================================
 *  Unity版本：2021.3.16f1c1
 *  作 者：熊熊 
 *  主要功能：玩家信息存储类
 *  创建时间：2023-01-28 16:20:43
 *  版 本：1.0
 * =======================================================*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoSingleton<PlayerModel>
{

    //这里我帮你改成驼峰命名法咯--by红豆
    public PlayerAttribute playerPower = new PlayerAttribute("ZY#0101", "力量值", 4);//力量值
    public PlayerAttribute playerAgile = new PlayerAttribute("ZY#0102", "敏捷值", 4);//敏捷值
    public PlayerAttribute playerIntelligence = new PlayerAttribute("ZY#0103", "智力值", 4);//智力值
    public PlayerAttribute playerLucky = new PlayerAttribute("ZY#0104", "幸运值", 3);//幸运值
    public PlayerAttribute playerHp = new PlayerAttribute("HP", "生命值", 5);//生命值
    public PlayerAttribute playerGoldcoin = new PlayerAttribute("ZY#0109", "金币", 0);//金币值 

    public ItemAttribute powerSlice = new ItemAttribute("SP#0101", "力量碎片", 0);//力量碎片
    public ItemAttribute agileSlice = new ItemAttribute("SP#0102", "敏捷碎片", 0);//敏捷碎片
    public ItemAttribute intelligenceSlice = new ItemAttribute("SP#0103", "智力碎片", 0);//智力碎片
    public ItemAttribute luckSlice = new ItemAttribute("SP#0104", "幸运碎片", 0);//幸运碎片 

    public OtherAttribute headgear;//狼骨头套
    public OtherAttribute statue;//雕像 
    public OtherAttribute groupPhoto;//合影
    public OtherAttribute key;//钥匙

    public int luckyRate;//幸运除率

}
/// <summary>
/// 玩家属性信息类
/// </summary>
[Serializable]
public class PlayerAttribute : BaseGameAttribute
{
    public PlayerAttribute(string id, string Name, int myvaluae)
    {
        ID = id;
        name = Name;
        value = myvaluae;
    }
}
/// <summary>
/// 物品属性信息类
/// </summary>
[Serializable]
public class ItemAttribute : BaseGameAttribute
{

    public ItemAttribute(string id, string Name, int myvaluae)
    {
        ID = id;
        name = Name;
        value = myvaluae;
    }
}
/// <summary>
/// 其他物品属性信息类
/// </summary>
[Serializable]
public class OtherAttribute : BaseGameAttribute
{

    public OtherAttribute(string id, string Name)
    {
        ID = id;
        name = Name;
    }
}
[Serializable]
public class BaseGameAttribute
{
    public string ID; //ID
    public string name; //名称
    public string remarks; //备注 
    public int type; //类型
    public string describe;//描述
    public Sprite picture;//图片
    public int isDrop;//可否掉落 0是false 1是true
    public int weightDrop;//掉落权重 
    public int dropQuantity;//掉落数量
    public int isBuy;//是否可购买 0是false 1是true
    public int putOnWeight;//上架权重
    public int salesQuantity;//售卖数量
    public int coinPrice;//金币售价
    public int slicePrice;//碎片售价
    public string addAttribute;//添加属性 
    public int conversionRatio;//折合比例
    public int value;//值
    public Sprite icon;//图标icon

}
