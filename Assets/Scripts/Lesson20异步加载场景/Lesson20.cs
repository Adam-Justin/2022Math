using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lesson20 : MonoBehaviour
{
    AsyncOperation aso = null;
    // Start is called before the first frame update
    void Start()
    {
        // 同步加载场景
        // SceneManager.LoadScene("测试场景");        
    }

    /// <summary>
    /// 普通异步加载场景 + 调用回调函数
    /// </summary>
    /// <param name="scenenName">场景名称</param>
    void LoadSceneAsychonized(string scenenName)
    {
        // 加载场景
        AsyncOperation operation = SceneManager.LoadSceneAsync(scenenName);
        operation.completed += LoadSceneCompleted;
    }
    /// <summary>
    /// 场景加载完毕回调函数
    /// </summary>
    /// <param name="operation"></param>
    private void LoadSceneCompleted(AsyncOperation operation)
    {
        // 场景加载完成后执行的代码
        Debug.Log("Scene loaded successfully");

        // 在这里可以进行场景初始化，例如查找和初始化游戏对象，设置游戏状态等
    }

    /// <summary>
    /// 异步加载场景 + 协程的方式
    /// </summary>
    void LoadSceneAsychonizedWithCoroutine(string scenenName)
    {
        // 异步加载场景
        AsyncOperation operation = SceneManager.LoadSceneAsync(scenenName);

        // 防止加载完毕立即进入新场景中
        operation.allowSceneActivation = false;

        // 监控加载进度
        // 启动一个协程来监控加载进度
        StartCoroutine(LoadWaitScene(operation));
    }

    /// <summary>
    /// 协程的方式异步加载场景
    /// </summary>
    /// <param name="sceneName">场景名称</param>
    /// <returns></returns>
    IEnumerator LoadScene(string sceneName)
    {
        DontDestroyOnLoad(this.gameObject);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        Debug.Log("加载中...");
        yield return operation;
        // 后面的内容无法打印,因为场景被加载完毕,当前场景上游戏物体,脚本被移除
        Debug.Log("场景加载完毕后打印数据");
        // 要想场景加载完毕后也可以继续执行yield return 后的代码,需要使用 DontDestroyOnLoad 来保存数据
        // 注意: DontDestroyOnLoad这个代码要放在异步加载场景之前的任意位置,可以是在协程前,可以是在开启异步加载场景协程前.
       
        Debug.Log("加载场景时不销毁对象");

        // 场景加载结束,但不急着显示场景
        // 场景加载结束, 进度条更新一段
        // 接着加载场景中的其他信息
        // 加载怪物-怪物加载完毕进度条更新一段
        // 动态加载 场景模型
        // 这时候就认为加载完毕,进度条设置100%, 隐藏进度条
        
    }
    /// <summary>
    /// 自定义协程加载场景
    /// </summary>
    /// <param name="operation"></param>
    /// <returns></returns>
    IEnumerator LoadWaitScene(AsyncOperation operation)
    {
        // 获得加载进度
        while(! operation.isDone)
        {
            Debug.Log("加载中...\t进度: " + operation.progress);
            if (operation.progress >= 0.9f)
            {
                // 激活场景 Allow Scenes to be activated as soon as it is ready.
                operation.allowSceneActivation = true;
            }
            
            // 自己做个假的进度条
            yield return null;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 普通异步加载场景 + 回调函数
            LoadSceneAsychonized("测试场景");

            // 一异步加载场景 + 协程
            // LoadSceneAsychonizedWithCoroutine("测试场景");
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            // 开启协程 + 加载场景不销毁对象
            StartCoroutine(LoadScene("测试场景"));
        }
    }
}
