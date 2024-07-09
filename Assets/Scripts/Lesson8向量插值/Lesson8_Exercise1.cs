using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson8_Exercise1 : MonoBehaviour
{
    // ���Բ�ֵ--���������
    public Transform targetTransform;

    public float distanceBehind = 4.0f; // �������������ľ���
    public float heightOffset = 7.0f; // ������ĸ߶�ƫ��
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // ����������Ŀ����λ��
        Vector3 targetPosition = targetTransform.position - targetTransform.forward * distanceBehind + Vector3.up * heightOffset;

        // �����ƽ���ƶ�
        this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, Time.deltaTime);
        // ���������Ŀ��
        this.transform.LookAt(targetPosition);

        Debug.Log(Camera.main.transform.position);
    }
}
