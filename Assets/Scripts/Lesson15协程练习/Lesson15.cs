using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


class Cup
{
    string name;    // ����
    float length;   // ��
    float width;    // ��
    float height;   // ��
    float weight;   // ��

    public Cup() { }

    public Cup(string name, float length, float width, float height, float weight)
    {
        this.name = name;
        this.length = length;
        this.width = width;
        this.height = height;
        this.weight = weight;
    }
    public override String ToString()
    {
        return ("��������:"+this.name + "���ӳ���:"+length as string + "���ӿ��:" + width as string + "���Ӹ߶�:" + height as string +"��������:" + weight as string);
    }
}
public class Lesson15 : MonoBehaviour
{
    float time = 0.0f;
    IEnumerator ie;
    // Э�̵ı��� �ǵ�����-->�ֲ�ִ��

    IEnumerator MyCorntinue()
    {
        Debug.Log("��һ��ִ��");
        yield return 1;
        Debug.Log("�ڶ���ִ��");
        yield return 2;
        Debug.Log("������ִ��");
        yield return 3;
        Debug.Log("���Ĵ�ִ��");
         yield return new Cup("èצ��", 6.0f,6.0f,10.0f, 50.0f);
    }

    /// <summary>
    /// ִ��Э��
    /// </summary>
    /// <param name="ie">Э�̵�����</param>
    /// <param name="time">��ʱʱ��</param>
    public void ExecCortinue( ref IEnumerator ie, ref float time)
    {
        // ʹ�ü�ʱʵ�ַ�ʱִ��
        if (time >= 1)
        {
            // �ֲ�ִ��
            if (ie.MoveNext())
            {
                Debug.Log(ie.Current.ToString());
                time = 0.0f;
            }
        }
    }

    void Start()
    {
        // ����Э��
        ie = MyCorntinue();
    }

    void Update()
    {
        // ��ʱ
        time += Time.deltaTime;
        // ִ��Э��
        ExecCortinue(ref ie, ref time);
    }
}
