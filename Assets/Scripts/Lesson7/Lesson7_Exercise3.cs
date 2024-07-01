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
        // ��ȡA��B��λ��
        positionA = objectA.position;
        positionB = objectB.position;

        // ����A��B������
        Vector3 directionAB = positionB - positionA;

        // �жϾ���
        if (directionAB.magnitude < detectionDistance)
        {
            // ��ȡA��ǰ����
            Vector3 forwardA = objectA.forward;

            // ��ˣ��ж�ǰ��
            float dotProduct = Vector3.Dot(forwardA, directionAB.normalized);
            bool isFront = dotProduct > 0;

            // ��ˣ��ж�����
            Vector3 crossProduct = Vector3.Cross(forwardA, directionAB);
            bool isRight = crossProduct.y > 0;

            // ����Ƕ�
            float angle = Mathf.Acos(dotProduct) * Mathf.Rad2Deg;

            // �жϽǶȺͷ���
            if ( (isFront && !isRight && angle < angleThreshold1))
            {
                Debug.Log("��ǰ��" + angleThreshold1 +"��, ���ֵ���");
                DrawLine(positionA, positionB, Color.red);
            }
            if ( (isFront && isRight && angle < angleThreshold2))
            {
                Debug.Log("��ǰ��" + angleThreshold2 +"��, ���ֵ���");
                DrawLine(positionA, positionB, Color.green);
            }
            
        }
    }

    void DrawLine(Vector3 start, Vector3 end, Color color)
    {
        Debug.DrawLine(start,end,color);
    }
}
