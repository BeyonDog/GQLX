/* =======================================================
 *  Unity版本：2021.3.16f1

 *  作 者：Puma
 *  主要功能：利用mono来测试功能

 *  创建时间：2023-01-29 14:36:34
 *  版 本：1.0
 * =======================================================*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var i = GQLX.Game.Map.BlockRegistrar.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
