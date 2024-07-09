using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson18Exercise : MonoBehaviour
{
    private Texture texture;

    private void Start()
    {
        // 调用加载函数 -- 拉姆达表达式
        /*        ResourceLoadManager.Instance.LoadResourceAsynchionzed<Texture>("Pictures/Picture", (obj) =>
                {
                    texture = obj;
                });*/

        // 普通单例异步加载 -- 加载图片资源
        ResourceLoadManager.Instance.LoadResourceAsynchionzed<Texture>("Pictures/Picture", OnpictureLoaded);
        // 协程单例异步加载-- 加载图片资源
        ResourceLoadManager.Instance.LoadResourceAsynchionzedCoroutine<Texture>("Pictures/Picture", OnpictureLoaded);
    }

    private void OnpictureLoaded(Texture loadedTexture)
    {
        texture = loadedTexture;
    }

    private void OnGUI()
    {
        if (texture != null)
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), texture);
        }
    }
}
