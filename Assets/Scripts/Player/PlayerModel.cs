/* =======================================================
 *  Unity版本：2021.3.16f1c1
 *  作 者：熊熊 
 *  主要功能：玩家信息存储类
 *  创建时间：2023-01-28 16:20:43
 *  版 本：1.0
 * =======================================================*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel: BaseSingleton<PlayerModel>
{
    public PlayerPower playerPower;
    public class PlayerPower
    {
        public string ID = "ZY#0101";
        public string name = "力量值";
        public string remarks = "力量值";
        public int type = 1;
    }
}
/// <summary>
/// 力量值
/// </summary>

