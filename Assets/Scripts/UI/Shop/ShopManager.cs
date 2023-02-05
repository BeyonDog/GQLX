/* =======================================================
 *  Unity版本：2021.3.16f1c1

 *  作 者：熊熊
 *  主要功能：商店控制脚本 

 *  创建时间：2023-02-03 13:10:41
 *  版 本：1.0
 * =======================================================*/

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{

    public List<ItemAttribute> salesItems;
    public GameObject[] commodity=new GameObject[3];//售卖物品栏

    private void Start()
    {
        ItemsInit();
    }

    /// <summary>
    /// 商店数据初始化
    /// </summary>
    public void ItemsInit()
    {
        ItemAttribute a=new ItemAttribute("SP#0101","力量碎片",100);
        a.isBuy = 0;
        salesItems.Add(a);
        a=new ItemAttribute("SP#0102","敏捷碎片",100);
        salesItems.Add(a);
        a.isBuy = 0;
        a=new ItemAttribute("SP#0103","智力碎片",100);
        salesItems.Add(a);
        a.isBuy = 0;
        a=new ItemAttribute("SP#0104","幸运碎片",100);
        salesItems.Add(a);
        a.isBuy = 0;
        for (int i = 0; i < 3; i++)
        {   
            //图标加载
            //commodity[i].GetComponent<Image>().sprite= ****
            commodity[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text= salesItems[i].name;
            // 添加按钮点击事件 
            commodity[i].transform.GetChild(1).GetComponent<Button>().onClick.AddListener(()=>
            {
                BuyItem(salesItems[i]);
            });
        }
    }
    
    /// <summary>
    /// 购买物品方法
    /// </summary>
    /// <param name="saleitem"></param>
    public void BuyItem(ItemAttribute saleitem)
    {
        if (saleitem.isBuy == 0)
        {
            if (PlayerModel.Instance.playerGoldcoin.value > saleitem.coinPrice && saleitem.value>0)
            {
                PlayerModel.Instance.playerGoldcoin.value -= (int)saleitem.coinPrice;
                switch (saleitem.ID)
                {
                    
                    case  "SP#0101"://力量碎片
                        PlayerModel.Instance.powerSlice.value++;
                        
                        break;
                    case  "SP#0102"://敏捷碎片
                        PlayerModel.Instance.agileSlice.value++;
                        break;
                    case  "SP#0103"://智力碎片
                        PlayerModel.Instance.intelligenceSlice.value++;
                        break;
                    case  "SP#0104"://幸运碎片
                        PlayerModel.Instance.luckSlice.value++;
                        break;
                }
                saleitem.value--;
                //显示购买成功UI提示
            }
            else
            {
                //写弹出UI提示逻辑，金币不足无法购买 
                Debug.Log("你没钱");
            }
        }
    }
}
