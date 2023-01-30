/* =======================================================
 *  Unity版本：2021.3.16f1c1

 *  作 者：
 *  主要功能：

 *  创建时间：2023-01-30 14:12:40
 *  版 本：1.0
 * =======================================================*/
/* =======================================================
 *  Unity版本：2021.3.16f1c1
 *  作 者：熊熊
 *  主要功能：Json文件的处理，游戏存档
 *  创建时间：2023-01-28 15:52:44
 *  版 本：1.0
 * =======================================================*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

public class JsonManager : MonoSingleton<JsonManager>
{
    private void Start()
    {
        Save();
    }

    public void Save()
    {
        PlayerModelInfoRoot playerModelInfoRoot = new PlayerModelInfoRoot();
        PlayerModelInfo modelInfo = new PlayerModelInfo();
        PlayerModelInfo modelInfo2 = new PlayerModelInfo();
        PlayerModelInfo[] modelInfos = new PlayerModelInfo[5];
        modelInfo.playerAttributeinfo=PlayerModel.Instance.playerPower;
        modelInfo2.playerAttributeinfo=PlayerModel.Instance.playeragile;
        
        // modelInfos[0].playerAttributeinfo = PlayerModel.Instance.playerPower;
        // modelInfos[1].playerAttributeinfo = PlayerModel.Instance.playeragile;
        playerModelInfoRoot.playerAttributeinfos.Add(modelInfo);
        playerModelInfoRoot.playerAttributeinfos.Add(modelInfo2);
        
        var vbasePath = Path.Combine(Application.streamingAssetsPath, "Config");
        DirectoryInfo dir = new DirectoryInfo(vbasePath);
        if (!dir.Exists)
            dir.Create(); //创建文件夹
            
        var vconfigPath = Path.Combine(vbasePath, "Save.json");
        FileInfo fileInfo = new FileInfo(vconfigPath);
        if (fileInfo.Exists)
            fileInfo.Delete();

        StreamWriter writer = fileInfo.CreateText(); //创建文件
        writer.Write(JsonUtility.ToJson(playerModelInfoRoot));
        writer.Flush();       
        writer.Dispose();
        writer.Close();
        
        AssetDatabase.Refresh(); //刷新unity工程，只能在编辑器模式下使用
    }
}
[Serializable]
public class PlayerModelInfo
{
    public BaseGameAttribute playerAttributeinfo=new BaseGameAttribute();
}
    
public class PlayerModelInfoRoot
{  
    public List<PlayerModelInfo> playerAttributeinfos=new List<PlayerModelInfo>();
        
} 