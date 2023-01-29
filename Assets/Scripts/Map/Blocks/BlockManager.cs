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
    public class BlockManager : BaseSingleton<BlockManager>
    {
        Dictionary<string, Block.BlockAbstract> BlockDic = new();

        public BlockManager()
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

        public Block.BlockAbstract GetBlockInfo(Block.BlockDate date)
        {
            if (date.blockName != null && BlockDic.ContainsKey(date.blockName))
            {
                return BlockDic[date.blockName];
            }
            else
            {
                Debug.LogError($"Can not Get Block info \"{date.blockName}\"");
                List<string> keys = new List<string>(BlockDic.Keys);
                return BlockDic[keys[0]];
            }
        }
    }

    public class BlockSprineManager : BaseSingleton<BlockSprineManager>
    {
        Dictionary<string, Sprite> spriteDic = new();
        string blockSpritesPath = "DelverTiles";

        public BlockSprineManager()
        {
            Sprite[] sprites = Resources.LoadAll<Sprite>(blockSpritesPath);
            if(sprites == null)
            {
                Debug.LogError($"Can not Find \"{blockSpritesPath}\"");
            }
            foreach(Sprite sprite in sprites)
            {
                spriteDic.Add(sprite.name, sprite);
                // Debug.Log($"Registed Block Sprite\"{sprite.name}\"");
            }
            Debug.Log($"Total Registed {spriteDic.Count} block sprites");
        }

        public Sprite GetSprite(string spriteName)
        {
            if (spriteDic.ContainsKey(spriteName))
            {
                return spriteDic[spriteName];
            }
            else
            {
                Debug.LogError($"Can not find \"{spriteName}\" form \"{blockSpritesPath}\"");
                return null;
            }
        }
    }
}
