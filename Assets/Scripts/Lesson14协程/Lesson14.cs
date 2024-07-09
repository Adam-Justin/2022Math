using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson14 : MonoBehaviour
{
    Coroutine c1;
    Coroutine c2;
    Coroutine c3;
    // Э�̳���
    // 1. Э�̵�ʹ��
    // 1.1 Э�̵�д��
    public IEnumerator MyCoroutine(int i, string str, float t)
    {
        print(i);
        // ����ֵIEumerator yield return ����ʱ����,���ȴ�����������ִ�к���
        yield return new WaitForSeconds(5.0f);              // �ȴ�5s��ִ��
        print(str);
        yield return new WaitForSeconds(3.0f);
        print(t);
        //yield return new WaitForEndOfFrame();               // �ȴ���ǰ֡������Ϻ�ִ��
        //print(t);
        //yield return new WaitForFixedUpdate();              // ֱ����һ���̶��������ڵ���ִ��
        //print(i);
    }
    // 2. ����Э��
    // 2.1 ��ͬ����ͨ�ĺ�������������Э��
    // MyCoroutine(3, "����ʹ����ͨ�������ÿ���/Э��", 5.0f);
    // 2.2 ��������1
    public void StartMyCoroutine1()
    {
        StartCoroutine(MyCoroutine(1, "����Э��1", 1.0f));
    }

    // 2.3 ��������2
    public void StartMyCoroutine2()
    {
        IEnumerator ie =  MyCoroutine(1, "����Э��2", 1.0f);
        StartCoroutine(ie);
    }
    // 2.4 �������Э��
    public void StartMyCoroutine3()
    {
        // ����Э�̺���д������
        c1 = StartCoroutine(MyCoroutine(1, "���Э��1", 1.0f));
        c2 = StartCoroutine(MyCoroutine(1, "���Э��2", 1.0f));
        c3 = StartCoroutine(MyCoroutine(1, "���Э��3", 1.0f));
       
    }
    // 3. �ر�Э��
    public void CloseAllCoroutine()
    {
        StopAllCoroutines();
    }
    // 4. �ر�ָ��Э��
    public void CloseSpecialCoroutine()
    {
        StopCoroutine(c1);
        StopCoroutine(c2);
        StopCoroutine(c3);
        // StopCoroutine(IEnumerator routine); ͨ��IEnumerator�ر�              
        // StopCoroutine(Coroutine routine);   ͨ��Э�����ƹر�
        // StopCoroutine(string methodName);   ͨ��Э�̺������ر�
    }

    // 5. ��ǰ����Э��
    public void BreakCoroutine()
    {
        IEnumerator MyNewCoroutine()
        {
            Debug.Log("��ʼִ��Эͬ����");

            // ִ��һЩ����
            yield return new WaitForSeconds(1.0f);
            Debug.Log("Эͬ����ִ����һ��");

            // ��������Ǽ��һ������
            if (SomeCondition())
            {
                Debug.Log("������������ǰ����Эͬ����");
                yield break; // ��ǰ��ֹЭͬ����
            }

            // �����������������㣬�⽫����ִ��
            yield return new WaitForSeconds(1.0f);
            Debug.Log("Эͬ������ִ����һ��");
        }
        StartCoroutine(MyNewCoroutine());

    }
    bool SomeCondition()
    {
        // �������������߼�
        return true; // ���磬ʼ�շ��� true ����ֹЭͬ����
    }
    void Start()
    {
        StartMyCoroutine1();
        StartMyCoroutine2();
        StartMyCoroutine3();
        CloseSpecialCoroutine();
        BreakCoroutine();
        // CloseAllCoroutine();
    }


}
