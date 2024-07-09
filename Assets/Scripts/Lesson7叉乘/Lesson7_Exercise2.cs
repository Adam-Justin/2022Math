using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson7_Exercise2 : MonoBehaviour
{
    // �ж�B������A���������,����,����,����
    public Transform transformA;
    public Transform transformB;

    // Update is called once per frame
    // ��˼���ǰ��,��˼�������
    float dotRet = 0.0f;
    float dotRetNormalized = 0.0f;
    Vector3 crossRet;
    float degree = 0.0f;
    float distance = 0.0f;
    void Update()
    {
        dotRet = Vector3.Dot(transformA.forward, (transformB.position - transformA.position));
        crossRet = Vector3.Cross(transformA.forward, transformB.position);
        // ����Ƕ�
        dotRetNormalized = Vector3.Dot(transformA.forward, (transformB.position - transformA.position).normalized);
        degree = Mathf.Acos(dotRetNormalized) * Mathf.Rad2Deg;
        distance = Vector3.Distance(transformA.position, transformB.position);

        // ���޼������
        if (distance <= 5.0f)
        {
            Debug.DrawLine(transformA.position, transformB.position, Color.red);
            if (dotRet > 0)
            {
                // ǰ
                if (crossRet.y > 0)
                {
                    print("B��A����ǰ����");
                    if (degree < 20)
                    {
                        print("��ǰ��30�㷢�ֵ���");
                    }
                }
                // ǰ
                if (crossRet.y < 0)
                {
                    print("B��A����ǰ����");
                    if (degree < 20)
                    {
                        print("��ǰ��20�㷢�ֵ���");
                    }
                }
            }

            if (dotRet < 0)
            {
                // ��
                if (crossRet.y > 0)
                {
                    print("B��A���Һ���");
                }
                // ��
                if (crossRet.y < 0)
                {
                    print("B��A�������");
                }
            }
        }
        
    }
}
