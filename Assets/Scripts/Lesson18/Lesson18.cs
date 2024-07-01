using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson18 : MonoBehaviour
{
    // 异步加载数据
    // 加载图片

    private Texture texture;

    private void Start()
    {
        // 普通异步加载
        // MyAsychonizedLoad();
        // 异步加载--协程模式加载
        StartCoroutine(LoadOver());

        // StartCoroutine(LoadOverDetial());

    }
    void MyAsychonizedLoad()
    {
        // 异步加载--会消耗帧, 所以有很多资源的时候需要写一个加载的进度条
        ResourceRequest re = Resources.LoadAsync<Texture>("Pictures/Picture");
        // 是否加载结束
        re.completed += Re_completed;
        // 打印帧数
        Debug.Log(Time.frameCount);

    }

    /// <summary>
    /// 加载完毕回调函数
    /// </summary>
    /// <param name="obj">得到的资源类</param>
    private void Re_completed(AsyncOperation obj)
    {
        Debug.Log("资源加载完毕");
        // 打印帧数
        Debug.Log(Time.frameCount);
        // 对资源赋值
        // 先类型转换 在赋值
        ResourceRequest rq = obj as ResourceRequest;
        if (rq != null)
        {
            texture = rq.asset as Texture;
        }
        
    }

    /// <summary>
    /// 使用协程加载资源
    /// </summary>
    /// <returns>ResourceRequest </returns>
    IEnumerator LoadOver()
    {
        // 加载资源
        ResourceRequest rq = Resources.LoadAsync<Texture>("Pictures/Picture");
        // 打印帧数
        Debug.Log(Time.frameCount);
        // 加载完毕
        yield return rq;
        // 加载完毕继续执行, 为什么yield return re呢? 因为ResourceRequest继承了AsyncOperation
        // 而AsyncOperation 继承了 YieldInstruction 且协程Coroutine中也是继承了 YieldInstruction
        // 所以大家继承了同一个类 当你使用 yield return re; 时，
        // 你实际上是在告诉协程：“在这里暂停执行，直到 re 这个异步操作完成。”
        // 这意味着协程会在这里等待，直到资源加载完成。
        // 一旦资源加载完成，协程就会从 yield return 语句的下一条语句继续执行。

        // 打印帧数
        Debug.Log(Time.frameCount);
        // 资源加载完毕后,继续执行
        texture = rq.asset as Texture;


    }

    /// <summary>
    /// 协程异步加载详解
    /// </summary>
    /// <returns></returns>
    IEnumerator LoadOverDetial()
    {
        // 加载资源
        ResourceRequest rq = Resources.LoadAsync<Texture>("Pictures/Picture");
        // 打印帧数
        Debug.Log(Time.frameCount);

        // 还可以获得加载的进度,是否加载完毕等数据
        while (!rq.isDone)
        {
            Debug.Log("资源加载优先级" + rq.priority);
            Debug.Log("资源加载进度" + rq.progress);
            yield return null;
        }

        texture = rq.asset as Texture;

    }

    /// <summary>
    /// 屏幕上绘制图片
    /// </summary>
    private void OnGUI()
    {
        if (texture != null)
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), texture);
        }
        
    }
}
