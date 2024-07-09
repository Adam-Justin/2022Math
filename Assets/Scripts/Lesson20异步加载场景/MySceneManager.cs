using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;



public class MySceneManager
{
    private static MySceneManager instance = new MySceneManager();
    private MySceneManager() { }

    public static MySceneManager Instance => instance;

    /// <summary>
    /// 外部调用异步加载场景的方法
    /// </summary>
    /// <param name="sceneName"> 场景名 </param>
    public void LoadScene(string sceneName, UnityAction action)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(sceneName);
        ao.completed += (a) =>
        {
            action(); // 调用外部的函数
        };
    }
}
