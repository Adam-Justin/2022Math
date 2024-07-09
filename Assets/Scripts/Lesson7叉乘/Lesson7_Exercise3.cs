using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson7_Exercise3 : MonoBehaviour
{
    public Transform objectA;
    public Transform objectB;

    Vector3 positionA = Vector3.zero;
    Vector3 positionB = Vector3.zero;

    public float detectionDistance = 5.0f;
    public float angleThreshold1 = 20.0f;
    public float angleThreshold2 = 30.0f;

    void Update()
    {
        // 获取A和B的位置
        positionA = objectA.position;
        positionB = objectB.position;

        // 计算A到B的向量
        Vector3 directionAB = positionB - positionA;

        // 判断距离
        if (directionAB.magnitude < detectionDistance)
        {
            // 获取A的前方向
            Vector3 forwardA = objectA.forward;

            // 点乘，判断前后
            float dotProduct = Vector3.Dot(forwardA, directionAB.normalized);
            bool isFront = dotProduct > 0;

            // 叉乘，判断左右
            Vector3 crossProduct = Vector3.Cross(forwardA, directionAB);
            bool isRight = crossProduct.y > 0;

            // 计算角度
            float angle = Mathf.Acos(dotProduct) * Mathf.Rad2Deg;

            // 判断角度和方向
            if ( (isFront && !isRight && angle < angleThreshold1))
            {
                Debug.Log("左前方" + angleThreshold1 +"度, 发现敌人");
                DrawLine(positionA, positionB, Color.red);
            }
            if ( (isFront && isRight && angle < angleThreshold2))
            {
                Debug.Log("右前方" + angleThreshold2 +"度, 发现敌人");
                DrawLine(positionA, positionB, Color.green);
            }
            
        }
    }

    void DrawLine(Vector3 start, Vector3 end, Color color)
    {
        Debug.DrawLine(start,end,color);
    }
}
