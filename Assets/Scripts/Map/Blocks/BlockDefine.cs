using UnityEngine;
using UnityEngine.Tilemaps;

namespace GQLX.Game.Map.Block
{
    public class Void : BlockAbstract
    {
        Tile tileDefault;

        public Void()
        {
            tileDefault = ScriptableObject.CreateInstance<Tile>();
            tileDefault.sprite = BlockSprineManager.Instance.GetSprite("DelverTiles_0");
            passable = false;
        }

        public override Tile GetTile(int data)
        {
            return tileDefault;
        }
    }

    public class Grass : BlockAbstract
    {
        Tile tileDefault;

        public override Tile GetTile(int data)
        {
            tileDefault = ScriptableObject.CreateInstance<Tile>();
            tileDefault.sprite = BlockSprineManager.Instance.GetSprite("DelverTiles_2");
            return tileDefault;
        }
    }
}
