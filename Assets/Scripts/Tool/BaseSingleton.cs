/* =======================================================
 *  Unity版本：2021.3.16f1c1
 *  作 者：熊熊
 *  主要功能：单例模式基类脚本
 *  创建时间：2023-01-28 15:52:44
 *  版 本：1.0
 * =======================================================*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 单例模式基类
/// </summary>
/// <typeparam name="T"></typeparam>
public class BaseSingleton<T> where T:new()
{
    private static T instance;
    public static T Instance
    {
        get 
        {
            if (instance == null)
            {
                instance = new T();
            }
            return instance;
        }
    }
}
/// <summary>
/// 继承mono的单例模式基类
/// </summary>
/// <typeparam name="T"></typeparam>
public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (T)FindObjectOfType(typeof(T));
                if (instance == null)
                {
                    //创建一个新的游戏对象并把单例组件挂在到游戏物体上
                    var singletonObj = new GameObject(typeof(T).ToString() + "(Singleton)");
                    instance = singletonObj.AddComponent<T>();
                    DontDestroyOnLoad(singletonObj);
               
                }
            }
            return instance;
        }
    }
}
