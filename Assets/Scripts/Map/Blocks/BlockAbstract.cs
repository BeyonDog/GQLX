using UnityEngine;

namespace GQLX.Game.Map.Block
{
    [System.Serializable]
    public struct BlockData
    {
        public string blockName;
        public int data;

        public BlockData(string blockName, int data)
        {
            this.blockName = blockName;
            this.data = data;
        }
    }

    public abstract class BlockAbstract
    {
        // 设置方块的默认属性
        public static bool passable = true; // 可通过性
        public static bool trigger = false; // 触发器

        /// <summary>
        /// <list type="table">
        /// <item>当玩家按下互动键时触发</item>
        /// <item>大部分情况下都不会有反应，因此基类作为打log</item>
        /// <item>请务必记得Base.Interact()以方便debug</item>
        /// </list>
        /// </summary>
        public virtual void Interact()
        {
            Debug.Log($"Interact with\"{GetType()}\"");
        }

        /// <summary>
        /// <list type="table">
        /// <item>方块的Trigger=True,且当玩家进入方块时触发</item>
        /// <item>请记得在Trigger设置为True时重载该函数</item>
        /// </list>
        /// </summary>
        public virtual void Trigger()
        {
            Debug.LogWarning($"Trigger with \"{GetType()}\", BUT YOU FORGET OVERRIDE \"Trigger()\"");
        }
    }
}