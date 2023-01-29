/* =======================================================
 *  Unity版本：2021.3.16f1c1
 *  作 者：熊熊
 *  主要功能：自动添加脚本注释
 *  创建时间：2023-01-28 15:52:44
 *  版 本：1.0
 * =======================================================*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScriptTemplate_editor : UnityEditor.AssetModificationProcessor
{
    //作者
    private const string Author = "";

    /// <summary>
    /// 资源创建时调用
    /// </summary>
    /// <param name="path">自动传入资源路径</param>
    public static void OnWillCreateAsset(string path)
    {
        path = path.Replace(".meta", "");
        if (!path.EndsWith(".cs")) return;
        //注意,Application.datapath会根据使用平台不同而不同
        string realPath = Application.dataPath.Replace("Assets", "") + path;
        string allText = "/* =======================================================\r\n"
                         + " *  Unity版本：#UnityVersion#\r\n\r\n"
                         + " *  作 者：#Author#\r\n"
                         + " *  主要功能：\r\n\r\n"
                         + " *  创建时间：#CreateTime#\r\n"
                         + " *  版 本：1.0\r\n"
                         + " * =======================================================*/\r\n";
        allText += File.ReadAllText(realPath);
        allText = allText.Replace("#UnityVersion#", Application.unityVersion);
        allText = allText.Replace("#Author#", Author);
        allText = allText.Replace("#CreateTime#", System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        File.WriteAllText(realPath, allText);
    }
}
