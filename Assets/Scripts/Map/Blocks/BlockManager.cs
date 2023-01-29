/* =======================================================
 *  Unity版本：2021.3.16f1

 *  作 者：Puma
 *  主要功能：维护和注册方块

 *  创建时间：2023-01-29 13:58:49
 *  版 本：1.0
 * =======================================================*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GQLX.Game.Map
{
    public class BlockRegistrar : BaseSingleton<BlockRegistrar>
    {
        Dictionary<string, Block.BlockAbstract> BlockDic = new();

        public BlockRegistrar()
        {
            Type baseType = typeof(Block.BlockAbstract);
            // 遍历程序集中的所有类型，并将继承自BlockAbstract的类添加到BlockDic中
            foreach(var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach(var type in assembly.GetTypes())
                {
                    if (baseType.IsAssignableFrom(type) && !type.IsAbstract)
                    {
                        BlockDic.Add(type.Name, Activator.CreateInstance(type) as Block.BlockAbstract);
                        Debug.Log($"Registed Block\"{type.Name}\"");
                    }
                }
            }
            Debug.Log($"Total registed {BlockDic.Count} blocks");
        }
    }
}
