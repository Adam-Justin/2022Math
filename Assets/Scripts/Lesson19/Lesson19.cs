using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson19 : MonoBehaviour
{
    // ����Ԥ����
    // ����ͼƬ

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
    /// ͼƬ�������
    /// </summary>
    /// <param name="texture"></param>
    void TextureLoaded(Texture texture)
    {
        this.texture = texture;
    }

    /// <summary>
    /// Ԥ����������
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
            //  ����ͼƬ��Դ
            ResourceLoadManager.Instance.LoadResourceAsynchionzedCoroutine<Texture>(picturePath, TextureLoaded);
            Debug.Log("ͼƬ��Դ�������");
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            //  ����Ԥ������Դ
            ResourceLoadManager.Instance.LoadResourceAsynchionzedCoroutine<GameObject>(gameObjectPath, GameObjectLoaded);
            Debug.Log("Ԥ������Դ�������");
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            // ж��ͼƬ��Դ
            Resources.UnloadAsset(texture);
            texture = null;
            Debug.Log("ͼƬж�����");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            // ж��������Դ
            Resources.UnloadUnusedAssets();
            GC.Collect();
            Debug.Log("������Դж�����");
        }
    }
}
