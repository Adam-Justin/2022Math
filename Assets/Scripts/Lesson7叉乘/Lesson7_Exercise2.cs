using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson7_Exercise2 : MonoBehaviour
{
    // 判断B物体在A物体的左上,左下,有上,右下
    public Transform transformA;
    public Transform transformB;

    // Update is called once per frame
    // 点乘计算前后,叉乘计算左右
    float dotRet = 0.0f;
    float dotRetNormalized = 0.0f;
    Vector3 crossRet;
    float degree = 0.0f;
    float distance = 0.0f;
    void Update()
    {
        dotRet = Vector3.Dot(transformA.forward, (transformB.position - transformA.position));
        crossRet = Vector3.Cross(transformA.forward, transformB.position);
        // 计算角度
        dotRetNormalized = Vector3.Dot(transformA.forward, (transformB.position - transformA.position).normalized);
        degree = Mathf.Acos(dotRetNormalized) * Mathf.Rad2Deg;
        distance = Vector3.Distance(transformA.position, transformB.position);

        // 有限计算距离
        if (distance <= 5.0f)
        {
            Debug.DrawLine(transformA.position, transformB.position, Color.red);
            if (dotRet > 0)
            {
                // 前
                if (crossRet.y > 0)
                {
                    print("B在A的右前方向");
                    if (degree < 20)
                    {
                        print("右前方30°发现敌人");
                    }
                }
                // 前
                if (crossRet.y < 0)
                {
                    print("B在A的左前方向");
                    if (degree < 20)
                    {
                        print("左前方20°发现敌人");
                    }
                }
            }

            if (dotRet < 0)
            {
                // 后
                if (crossRet.y > 0)
                {
                    print("B在A的右后方向");
                }
                // 后
                if (crossRet.y < 0)
                {
                    print("B在A的左后方向");
                }
            }
        }
        
    }
}
