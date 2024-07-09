using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson6 : MonoBehaviour
{
    public GameObject targetGameObjecct;
    float dotResult = 0.0f;
    float angel = 0.0f;

    // Update is called once per frame
    void Update()
    {
        // Debug.DrawLine(this.transform.position, targetGameObjecct.transform.position, Color.red);
        // Debug.DrawRay(this.transform.position, this.transform.forward, Color.green);
        // Debug.DrawRay(this.transform.position, (targetGameObjecct.transform.position - this.transform.position), Color.red);
        dotResult = Vector3.Dot(this.transform.forward, (targetGameObjecct.transform.position - this.transform.position).normalized);
        angel = Mathf.Acos(dotResult) * Mathf.Rad2Deg;
        // Ҳ������ʹ��Ĭ�ϵ�API
        Vector3.Angle(this.transform.forward, (targetGameObjecct.transform.position - this.transform.position));
        if (dotResult > 0)
        {
            Debug.Log("ǰ��");
            DrawLine(Color.red);
            print("�н�Ϊ: " + angel);
        }
        if (dotResult == 0)
        {
            Debug.Log("һ������");
            DrawLine(Color.blue);
            print("�н�Ϊ: " + angel);
        }
        if (dotResult < 0)
        {
            Debug.Log("��");
            DrawLine(Color.green);
            print("�н�Ϊ: " + angel);
        }
    }

    public void DrawLine(Color color)
    {
        Debug.DrawRay(this.transform.position, (targetGameObjecct.transform.position - this.transform.position), color);
    }
}
