using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GQLX.Game;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Chunk chunk = new();
        chunk.SetBlock(new Vector2Int(0, 0), new GQLX.Game.Block.BlockData("Void", 0));
        string json = chunk.SerializeChunk();
        Debug.Log(json);
        Chunk chunk2 = Chunk.DeserializeChunk(json);
        json = chunk2.SerializeChunk();
        Debug.Log(json);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
