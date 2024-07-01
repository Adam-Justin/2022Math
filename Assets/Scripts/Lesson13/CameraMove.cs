using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform target;                // ���������Ŀ��
    public float headOffset = 1.0f;         // ���������ƫ��λ��
    public float angle = 45.0f;             // ��б�Ƕ�

    public float distance = 5.0f;           // �����Ĭ�ϵľ���
    public float maxDistance = 10.0f;       // ������������
    public float minDistance = 3.0f;        // ��������С����
    public float scrollSpeed = 1.0f;        // ���������ٶ�

    private Vector3 nowPosition;            // �������ǰλλ��

    private Vector3 nowDir;                 // �����λ�õ�Ŀ��λ�õ�����

    public float rotateSpeed = 1.0f;        // �������ת�ٶ�
    public float moveSpeed = 1.0f;          // ����������ٶ�
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ChangeCameraDistance(ref distance, minDistance, maxDistance, scrollSpeed);

        CameraFollow(ref distance);
       
    }

    /// <summary>
    /// �����ƫ��
    /// </summary>
    /// <param name="distance"></param>
    private void CameraFollow(ref float distance)
    {
        // �������������target�����ϵ�λ��
        nowPosition = target.position + target.up * headOffset;
        // ��ƫ��λ��-----�������������������right��ת��angle����, �����������������ĵ�,
        // ��ôʵ���ϵ�Ч�����������������������������½����˶��پ���,��������ϻ����µľ���
        // ����������µı仯ֵ��ͨ�����Ǻ������Լ���õ���==>ͨ����ת�������Ϊ����ԭ����ת, �˵�ı仯�Ĵ�ֱ����Ϊdistance * sin(angle)

        // ��õ�ǰ�������targetĿ�������
        nowDir = Quaternion.AngleAxis(angle, target.right) * (-this.transform.forward);

        nowPosition = nowPosition + nowDir * distance;
        // this.transform.position = nowPosition; 
        this.transform.position = Vector3.Slerp(this.transform.position, nowPosition, Time.deltaTime * moveSpeed);
        Debug.DrawLine(this.transform.position, target.position + target.up * headOffset, Color.green);

        // ��ת����� -- ʹ���ȿ��������ת��ʽ
        // this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(-nowDir), Time.deltaTime * rotateSpeed);

        // ���޸�Ϊ
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(-target.up), Time.deltaTime * rotateSpeed);
        
    }

    /// <summary>
    /// �����޸��������������ľ���
    /// </summary>
    /// <param name="distance">�ⲿ����ľ���</param>
    private void ChangeCameraDistance(ref float distance, float minDistance, float maxDistance, float scrollSpeed)
    {
        // �������޸����������Taget�ľ���
        distance += Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        // ������������[Min, Max]��Χ��
        distance = Mathf.Clamp(distance, minDistance, maxDistance);
    }
}
