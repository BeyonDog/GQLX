using System.Collections.Generic;
using UnityEngine;
using GQLX.Game.Block;

namespace GQLX.Game
{
    /// <summary>
    /// Çø¿é
    /// </summary>
    [System.Serializable]
    public class Chunk
    {
        public BlockData[] blocks = new BlockData[256];

        public void SetBlock(Vector2Int pos, BlockData block)
        {
            if(pos.x < 0 || pos.x > 15 || pos.y < 0 || pos.y > 15)
            {
                Debug.LogError($"Set Block \"{block.blockName}\" to {pos} Out of Range");
                return;
            }

            blocks[pos.y * 16 + pos.x] = block;
            Debug.Log($"Set Block \"{block.blockName}\" to {pos}");
        }

        public BlockData GetBlockData(Vector2Int pos)
        {
            return blocks[pos.y * 16 + pos.x];
        }

        public string SerializeChunk()
        {
            return JsonUtility.ToJson(this);
        }

        public static Chunk DeserializeChunk(string json)
        {
            return JsonUtility.FromJson<Chunk>(json);
        }
    }
}
