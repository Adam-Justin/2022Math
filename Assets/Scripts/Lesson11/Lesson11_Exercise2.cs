using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson11_Exercise2 : MonoBehaviour
{
    // ʵ��������������
    public Transform targetTransform;


    [Header("������ƶ����")]
    public float distanceBehind = 4.0f;         // �������������ľ���
    public float heightOffset = 7.0f;           // ������ĸ߶�ƫ��

    private Vector3 startPosition;              // ��������λ��
    private Vector3 targetPosition;             // ������յ�λ��
    private float moveTime = 0.0f;
    public float moveSpeed = 1.0f;              // �ƶ��ٶ�

    [Header("�������ת���")]
    private float roundTime = 0.0f;
    private Quaternion startRotation;           // �������ת���
    private Quaternion targetRotation;          // �������ת�յ�
    public float roundSpeed = 1.0f;             // �������ת�ٶ�


    void Start()
    {
        // ��ʼ�����
        // ���Բ��ó�ʼ��
        targetPosition = targetTransform.position - targetTransform.forward * distanceBehind + Vector3.up * heightOffset;
        targetRotation = Quaternion.LookRotation(targetTransform.position - this.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        CameraFollow();
    }


    /// <summary>
    /// ���������-�����ƶ�����ת
    /// </summary>
    private void CameraFollow()
    {
        CameraFollowMoveAverage();
        CameraFollowRotateAverage();
    }
    /// <summary>
    /// ������ȿ��������
    /// </summary>
    private void CameraFollowMoveFast()
    {
        targetPosition = targetTransform.position - targetTransform.forward * distanceBehind + Vector3.up * heightOffset;
        // �ȿ����
        startPosition = this.transform.position;
        this.transform.position = Vector3.Slerp(startPosition, targetPosition, Time.deltaTime * moveSpeed);
    }

    /// <summary>
    /// �����ƽ������
    /// </summary>
    private void CameraFollowMoveAverage()
    {
        // �����ƽ���ƶ�
        if (targetPosition != targetTransform.position - targetTransform.forward * distanceBehind + Vector3.up * heightOffset)
        {
            // �����յ�
            targetPosition = targetTransform.position - targetTransform.forward * distanceBehind + Vector3.up * heightOffset;
            // ����ʱ��
            moveTime = 0.0f;
            // �������
            startPosition = this.transform.position;

        }
        moveTime += Time.deltaTime;
        this.transform.position = Vector3.Slerp(startPosition, targetPosition, moveTime * moveSpeed);
    }

    /// <summary>
    /// �����������������ת
    /// </summary>
    private void CameraFollowRotateAverage()
    {
        // �����˶� --��һ�������յ㲻��, �����ʱ�������յ�Ҫ��
        if (targetRotation != Quaternion.LookRotation(targetTransform.position - this.transform.position))
        {
            // �����յ�
            targetRotation = Quaternion.LookRotation(targetTransform.position - this.transform.position);
            // ����ʱ��
            roundTime = 0.0f;
            // �������
            startRotation = this.transform.rotation;
        }
        roundTime += Time.deltaTime;
        this.transform.rotation = Quaternion.Slerp(startRotation, targetRotation, roundTime);
    }

    /// <summary>
    /// ������ȿ�����������ת
    /// </summary>
    public void CameraFollowRotateFast()
    {
        // ������ת��Ԫ��
        targetRotation = Quaternion.LookRotation(targetTransform.position - this.transform.position);
        // Slerp��ת����Ч��

        // �ȿ���� -- �Լ�����Ԫ��-Ŀ����Ԫ��-Time.deltaTime
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetRotation, Time.deltaTime * roundSpeed);
    }
}
