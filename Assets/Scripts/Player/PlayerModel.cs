/* =======================================================
 *  Unity版本：2021.3.16f1c1
 *  作 者：熊熊 
 *  主要功能：玩家信息存储类
 *  创建时间：2023-01-28 16:20:43
 *  版 本：1.0
 * =======================================================*/
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerModel: BaseSingleton<PlayerModel>
{
    
    public PlayerAttribute playerPower;//玩家力量值
    
    
    
    /// <summary>
    /// 玩家属性信息类
    /// </summary>
    public class PlayerAttribute :BaseGameAttribute
    {

        public  PlayerAttribute(string id,string name)
        {
            
        }
    }

    /// <summary>
    /// 物品属性信息类
    /// </summary>
    public class ItemAttribute :BaseGameAttribute
    {

        public ItemAttribute(string id,string name)
        {
            
        }
    }
    /// <summary>
    /// 其他物品属性信息类
    /// </summary>
    public class OtherAttribute : BaseGameAttribute
    {
        
        public OtherAttribute(string id, string name)
        {
            
        }
    }

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
        public int isBuy;//是否可购买 
        public int putOnWeight;//上架权重
        public int salesQuantity;//售卖数量
        public float coinPrice;//金币售价
        public float slicePrice;//碎片售价
        public string addAttribute;//添加属性 
        public int conversionRatio;//折合比例
        public int value;//值
        public Sprite icon;//图标icon
    }
}


