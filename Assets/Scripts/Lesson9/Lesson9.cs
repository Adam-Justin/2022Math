using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson9 : MonoBehaviour
{
    GameObject go;
    // ��Ԫ����ת����
    // ��Ԫ��Q = [cos(��/2), sin(��/2)x,sin(��/2)y,sin(��/2)z]

    // ��,�Ƕ� ����x����ת30��
    Quaternion q1 = new Quaternion(Mathf.Sin(30 * Mathf.Deg2Rad) * 1, 0, 0, Mathf.Cos(30 * Mathf.Deg2Rad));
    void Start()
    {
        go = GameObject.CreatePrimitive(PrimitiveType.Cube);
        // go.transform.rotation = q1;
        // go.transform.rotation  rotation������Ԫ��, ������rotation��ͬ

        // ����ĸ���д�����Ա�Unity��װ�õķ���д -- �Ƕ�+��
        Quaternion q2 = Quaternion.AngleAxis(60, Vector3.right);
        // go.transform.rotation = q2;

        // ŷ����ת��Ԫ��
        Quaternion q3 = Quaternion.Euler(60, 0, 0);
        Debug.Log(q3);

        // ��Ԫ��תŷ����
        Debug.Log(q3.eulerAngles);
    }
    private void Update()
    {
        go.transform.rotation *= Quaternion.AngleAxis(1, Vector3.up);
    }


}
