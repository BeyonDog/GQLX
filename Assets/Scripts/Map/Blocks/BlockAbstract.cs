namespace GQLX.Game.Block
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

    public abstract class BlockAttribute
    {
        public static bool passable = true;
    }
}