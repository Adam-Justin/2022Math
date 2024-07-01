using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson19 : MonoBehaviour
{
    // 加载预制体
    // 加载图片

    private GameObject go;
    private Texture texture;

    private string picturePath;
    private string gameObjectPath;

    private void Start()
    {
        picturePath = "Picture/Picture";
        gameObjectPath = "Cube";
    }

    /// <summary>
    /// 图片加载完毕
    /// </summary>
    /// <param name="texture"></param>
    void TextureLoaded(Texture texture)
    {
        this.texture = texture;
    }

    /// <summary>
    /// 预制体加载完毕
    /// </summary>
    /// <param name="texture"></param>
    void GameObjectLoaded(GameObject go)
    {
        this.go = go;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            //  加载图片资源
            ResourceLoadManager.Instance.LoadResourceAsynchionzedCoroutine<Texture>(picturePath, TextureLoaded);
            Debug.Log("图片资源加载完毕");
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            //  加载预制体资源
            ResourceLoadManager.Instance.LoadResourceAsynchionzedCoroutine<GameObject>(gameObjectPath, GameObjectLoaded);
            Debug.Log("预制体资源加载完毕");
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            // 卸载图片资源
            Resources.UnloadAsset(texture);
            texture = null;
            Debug.Log("图片卸载完毕");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            // 卸载所有资源
            Resources.UnloadUnusedAssets();
            GC.Collect();
            Debug.Log("所有资源卸载完毕");
        }
    }
}
