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
        // 也还可以使用默认的API
        Vector3.Angle(this.transform.forward, (targetGameObjecct.transform.position - this.transform.position));
        if (dotResult > 0)
        {
            Debug.Log("前方");
            DrawLine(Color.red);
            print("夹角为: " + angel);
        }
        if (dotResult == 0)
        {
            Debug.Log("一条线上");
            DrawLine(Color.blue);
            print("夹角为: " + angel);
        }
        if (dotResult < 0)
        {
            Debug.Log("后方");
            DrawLine(Color.green);
            print("夹角为: " + angel);
        }
    }

    public void DrawLine(Color color)
    {
        Debug.DrawRay(this.transform.position, (targetGameObjecct.transform.position - this.transform.position), color);
    }
}
