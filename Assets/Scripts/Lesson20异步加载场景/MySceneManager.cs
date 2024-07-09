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
    /// �ⲿ�����첽���س����ķ���
    /// </summary>
    /// <param name="sceneName"> ������ </param>
    public void LoadScene(string sceneName, UnityAction action)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(sceneName);
        ao.completed += (a) =>
        {
            action(); // �����ⲿ�ĺ���
        };
    }
}
