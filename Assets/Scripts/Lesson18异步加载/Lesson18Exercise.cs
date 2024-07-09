using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson18Exercise : MonoBehaviour
{
    private Texture texture;

    private void Start()
    {
        // ���ü��غ��� -- ��ķ����ʽ
        /*        ResourceLoadManager.Instance.LoadResourceAsynchionzed<Texture>("Pictures/Picture", (obj) =>
                {
                    texture = obj;
                });*/

        // ��ͨ�����첽���� -- ����ͼƬ��Դ
        ResourceLoadManager.Instance.LoadResourceAsynchionzed<Texture>("Pictures/Picture", OnpictureLoaded);
        // Э�̵����첽����-- ����ͼƬ��Դ
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
