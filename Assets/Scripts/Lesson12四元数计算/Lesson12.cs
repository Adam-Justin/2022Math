using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson12 : MonoBehaviour
{
    // 四元数与四元数相乘
    Quaternion q1;
    // 四元数与向量相乘
    Quaternion q2;
    Vector3 v;
    // Start is called before the first frame update
    void Start()
    {
        q1 = Quaternion.AngleAxis(1, Vector3.up);
        q2 = Quaternion.AngleAxis(45, Vector3.up);
        // 构建向量
        v = Vector3.forward;
        // 四元素和向量相乘返回的是向量的时候一定是四元数在前,向量在后
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
