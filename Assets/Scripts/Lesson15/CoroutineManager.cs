using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class YieldReturnTime
{
    // �´���Ҫ����ִ�еĵ������ӿ�
    public IEnumerator ie;
    //�´���Ҫִ�е�ʱ��
    public float time;
}
// ��̬��Э�̹�����--���ܶ�Э��ʹ��
public class CoroutineManager : MonoBehaviour
{
    private static CoroutineManager instance;
    // �����洢���������صĽṹ
    private List<YieldReturnTime> list = new List<YieldReturnTime>();
    public static CoroutineManager Instance
    {
        get
        {
            return instance;
        }
        
    }
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }
    /// <summary>
    /// �Զ���Э��-��ʱ-�ֲ�
    /// </summary>
    /// <param name="ie">Э��</param>
    public void MyStartCoroutine(IEnumerator ie)
    {
        // һ��ʼ��ִ�� moveNextΪtrue������滹������
        if (ie.MoveNext())
        {
            // �жϷ���ֵ
            if (ie.Current is int)
            {
                // ���ص�������, ��Ҫ�ȴ� = ��ǰʱ��+�ȴ�ʱ��
                // ���������͵ȴ�ʱ���¼����,��ͣ����Ƿ���ʱ�䵽�˵Ļ�����������ִ��
                // ��¼��������������Ҫִ�е�ʱ��
                YieldReturnTime yrt = new YieldReturnTime();

                yrt.ie = ie;
                yrt.time = Time.time + (int)ie.Current;

                // ��ӵ���Э���б���--�����ж��Э�̺�������
                list.Add(yrt);

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // ���list������Э���Ƿ����Լ���ִ��ʱ��
        for (int i = list.Count - 1 ; i >= 0; i--)
        {
            //  �ж��Ƿ���ʱ��--��û��yield return x�ķ���ֵ
            if (list[i].time <= Time.time)
            {                
                // �ж��Ƿ�ִ������
                if (list[i].ie.MoveNext())
                {
                    // true ���滹��������Ҫ���沢ִ��
                    if (list[i].ie.Current is int)
                    {
                        list[i].time = Time.time + (int)list[i].ie.Current;
                    }
                    else 
                    {
                        // ��listֻ�Ǵ洢����ʱ����صĵ���������ֵ
                        // ������������͵���Ҫ����������list�л��ߵ�������
                        list.RemoveAt(i);
                    }
                }
                else
                {
                    // ����û������
                    list.RemoveAt(i);
                }
            }
            
        }
    }
}
