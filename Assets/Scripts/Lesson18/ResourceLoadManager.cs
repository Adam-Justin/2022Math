using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ResourceLoadManager : MonoBehaviour
{
    // �����첽�������ݹ�����--���ⲿһ���������ڼ�����Դ

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
        // ������Դ
        ResourceRequest rq = Resources.LoadAsync<T>(sourceName);
        // ������ϵ��ûص�����
        rq.completed += (a) =>
        {
            // �����ⲿ�Ļص����� -- ת����Դ
            callBack((a as ResourceRequest).asset as T);
            // �����غõ���Դͨ���ⲿ�ص���������
            Debug.Log("��Դת���ɹ�,���ѷ��ظ�����");
        };
    }

    /// <summary>
    /// ʹ��Э�̼���
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="sourceName"></param>
    /// <param name="callBack"></param>
    public void LoadResourceAsynchionzedCoroutine<T>(string sourceName, UnityAction<T> callBack) where T : Object
    {
        StartCoroutine(LoadSource<T>(sourceName, callBack));
    }

    // Э��
    IEnumerator LoadSource<T>(string sourceName, UnityAction<T> callBack) where T: Object
    {
        ResourceRequest rq = Resources.LoadAsync<T>(sourceName);
        yield return rq;
        callBack(rq.asset as T);
    }
}
