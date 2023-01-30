using System.Collections.Generic;
using UnityEngine;
using GQLX.Game.Map;
using UnityEngine.Tilemaps;

namespace GQLX.Game.Map
{
    /// <summary>
    /// ����
    /// </summary>
    [System.Serializable]
    public class Chunk
    {
        public Block.BlockDate[] blocks = new Block.BlockDate[256];

        public void blocks2Tilemap(Tilemap tilemap)
        {
            tilemap.size = new Vector3Int(16, 16, 0);
            for (int i = 0; i < blocks.Length; i++)
            {
                tilemap.SetTile(
                    new Vector3Int(i % 16, i / 16, 0),
                    BlockManager.Instance.GetBlockInfo(blocks[i]).GetTile(blocks[i].data));
            }
        }

        public void TileMap2Blocks(Tilemap tilemap)
        {

        }

        public void SetBlock(Vector2Int pos, Block.BlockDate block)
        {
            if (pos.x < 0 || pos.x > 15 || pos.y < 0 || pos.y > 15)
            {
                Debug.LogError($"Set Block \"{block.blockName}\" to {pos} Out of Range");
                return;
            }

            blocks[pos.y * 16 + pos.x] = block;
            Debug.Log($"Set Block \"{block.blockName}\" to {pos}");
        }
        public Block.BlockDate GetBlockData(Vector2Int pos)
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