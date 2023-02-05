// /* =======================================================
//  *  Unity版本：2021.3.16f1

//  *  作 者：Puma
//  *  主要功能：利用mono来测试功能

//  *  创建时间：2023-01-29 14:36:34
//  *  版 本：1.0
//  * =======================================================*/
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.Tilemaps;
// using UnityEngine.UI;
// using GQLX.Game.Map;
// using GQLX.Game.Map.Block;

// public class Test : MonoBehaviour
// {
//     // Start is called before the first frame update
//     void Start()
//     {
//         Tilemap tilemap = gameObject.GetComponent<Tilemap>();

//         Chunk chunk = new GQLX.Game.Map.Chunk();
//         chunk.SetBlock(new Vector2Int(4, 4), new BlockDate("Grass", 0));
//         chunk.SetBlock(new Vector2Int(6, 4), new BlockDate("Grass", 0));
//         chunk.SetBlock(new Vector2Int(6, 6), new BlockDate("Grass", 0));
//         chunk.SetBlock(new Vector2Int(8, 8), new BlockDate("Grass", 0));
//         chunk.SetBlock(new Vector2Int(8, 4), new BlockDate("Grass", 0));
//         chunk.SetBlock(new Vector2Int(4, 8), new BlockDate("Grass", 0));
//         chunk.blocks2Tilemap(tilemap);
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }
// }
