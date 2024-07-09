using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson8_Exercise2 : MonoBehaviour
{
    // ���β�ֵ--̫������������
    public Transform earthTransform;
    Vector3 startPos;
    Vector3 targetPos;
    Vector3 nowTargetPos;
    float distance = 200.0f;
    float time = 0.0f;
   
    
    // Start is called before the first frame update
    void Start()
    {
        startPos = Vector3.right * distance;
        targetPos = Vector3.left * distance + Vector3.up * 1.0f;
        nowTargetPos = targetPos;
        // this.transform.right * distance

    }


    void Update()
    {
        time += Time.deltaTime;

        if (nowTargetPos != targetPos)
        {
            // �����յ�
            nowTargetPos = targetPos;
            // �������
            startPos = this.transform.position;
            // ���ñ�����ʱ
            time = 0;

        }
        this.transform.position = Vector3.Slerp(startPos, targetPos, time * 0.1f);
        
       

    }
}
