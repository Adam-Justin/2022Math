using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson12 : MonoBehaviour
{
    // ��Ԫ������Ԫ�����
    Quaternion q1;
    // ��Ԫ�����������
    Quaternion q2;
    Vector3 v;
    // Start is called before the first frame update
    void Start()
    {
        q1 = Quaternion.AngleAxis(1, Vector3.up);
        q2 = Quaternion.AngleAxis(45, Vector3.up);
        // ��������
        v = Vector3.forward;
        // ��Ԫ�غ�������˷��ص���������ʱ��һ������Ԫ����ǰ,�����ں�
        print(v);
        v = q2 * v;
        print(v);
        v = q2 * v;
        print(v);
    }

    // Update is called once per frame
    void Update()
    {
        // this.transform.rotation *= q1;
    }
}
