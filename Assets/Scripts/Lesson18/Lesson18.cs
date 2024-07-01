using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson18 : MonoBehaviour
{
    // �첽��������
    // ����ͼƬ

    private Texture texture;

    private void Start()
    {
        // ��ͨ�첽����
        // MyAsychonizedLoad();
        // �첽����--Э��ģʽ����
        StartCoroutine(LoadOver());

        // StartCoroutine(LoadOverDetial());

    }
    void MyAsychonizedLoad()
    {
        // �첽����--������֡, �����кܶ���Դ��ʱ����Ҫдһ�����صĽ�����
        ResourceRequest re = Resources.LoadAsync<Texture>("Pictures/Picture");
        // �Ƿ���ؽ���
        re.completed += Re_completed;
        // ��ӡ֡��
        Debug.Log(Time.frameCount);

    }

    /// <summary>
    /// ������ϻص�����
    /// </summary>
    /// <param name="obj">�õ�����Դ��</param>
    private void Re_completed(AsyncOperation obj)
    {
        Debug.Log("��Դ�������");
        // ��ӡ֡��
        Debug.Log(Time.frameCount);
        // ����Դ��ֵ
        // ������ת�� �ڸ�ֵ
        ResourceRequest rq = obj as ResourceRequest;
        if (rq != null)
        {
            texture = rq.asset as Texture;
        }
        
    }

    /// <summary>
    /// ʹ��Э�̼�����Դ
    /// </summary>
    /// <returns>ResourceRequest </returns>
    IEnumerator LoadOver()
    {
        // ������Դ
        ResourceRequest rq = Resources.LoadAsync<Texture>("Pictures/Picture");
        // ��ӡ֡��
        Debug.Log(Time.frameCount);
        // �������
        yield return rq;
        // ������ϼ���ִ��, Ϊʲôyield return re��? ��ΪResourceRequest�̳���AsyncOperation
        // ��AsyncOperation �̳��� YieldInstruction ��Э��Coroutine��Ҳ�Ǽ̳��� YieldInstruction
        // ���Դ�Ҽ̳���ͬһ���� ����ʹ�� yield return re; ʱ��
        // ��ʵ�������ڸ���Э�̣�����������ִͣ�У�ֱ�� re ����첽������ɡ���
        // ����ζ��Э�̻�������ȴ���ֱ����Դ������ɡ�
        // һ����Դ������ɣ�Э�̾ͻ�� yield return ������һ��������ִ�С�

        // ��ӡ֡��
        Debug.Log(Time.frameCount);
        // ��Դ������Ϻ�,����ִ��
        texture = rq.asset as Texture;


    }

    /// <summary>
    /// Э���첽�������
    /// </summary>
    /// <returns></returns>
    IEnumerator LoadOverDetial()
    {
        // ������Դ
        ResourceRequest rq = Resources.LoadAsync<Texture>("Pictures/Picture");
        // ��ӡ֡��
        Debug.Log(Time.frameCount);

        // �����Ի�ü��صĽ���,�Ƿ������ϵ�����
        while (!rq.isDone)
        {
            Debug.Log("��Դ�������ȼ�" + rq.priority);
            Debug.Log("��Դ���ؽ���" + rq.progress);
            yield return null;
        }

        texture = rq.asset as Texture;

    }

    /// <summary>
    /// ��Ļ�ϻ���ͼƬ
    /// </summary>
    private void OnGUI()
    {
        if (texture != null)
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), texture);
        }
        
    }
}
