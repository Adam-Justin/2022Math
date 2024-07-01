using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ResourceLoadManager : MonoBehaviour
{
    // 单例异步加载数据管理器--给外部一个方法用于加载资源

    // private static ResourceLoadManager instance = new ResourceLoadManager();
    private static ResourceLoadManager instance;

    private ResourceLoadManager() { }
    public static ResourceLoadManager Instance 
    {
        get
        {
            return instance;
        }
    }
    private void Awake()
    {
        instance = this;
    }


    public void LoadResourceAsynchionzed<T>(string sourceName, UnityAction<T> callBack) where T : Object
    {
        // 加载资源
        ResourceRequest rq = Resources.LoadAsync<T>(sourceName);
        // 加载完毕调用回调函数
        rq.completed += (a) =>
        {
            // 调用外部的回调函数 -- 转换资源
            callBack((a as ResourceRequest).asset as T);
            // 将加载好的资源通过外部回调函数返回
            Debug.Log("资源转换成功,并已返回给对象");
        };
    }

    /// <summary>
    /// 使用协程加载
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="sourceName"></param>
    /// <param name="callBack"></param>
    public void LoadResourceAsynchionzedCoroutine<T>(string sourceName, UnityAction<T> callBack) where T : Object
    {
        StartCoroutine(LoadSource<T>(sourceName, callBack));
    }

    // 协程
    IEnumerator LoadSource<T>(string sourceName, UnityAction<T> callBack) where T: Object
    {
        ResourceRequest rq = Resources.LoadAsync<T>(sourceName);
        yield return rq;
        callBack(rq.asset as T);
    }
}
