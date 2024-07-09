using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson8 : MonoBehaviour
{
    public Transform startTransformA;
    public Transform startTransformB;
    public Transform endTransform;
    [Header("���β�ֵ")]
    public Transform startTransformC;
    public Transform slerpEndTransform;

    Vector3 startPos;
    Vector3 nowTargetPos;
    float time;

    void Start()
    {
        startPos = startTransformB.position;
        nowTargetPos = endTransform.position;
    }
    // Update is called once per frame
    void Update()
    {
        // ���㹫ʽ: result  =  start + (end - start) * t;
        // ��һ��
        startTransformA.position = Vector3.Lerp(startTransformA.position, endTransform.position, Time.deltaTime);
        Debug.DrawLine(startTransformA.position, endTransform.position, Color.green);

        // �ڶ���
        time += Time.deltaTime;
        // time >=1 ��ʱ��͵������յ�,�����t>=1��ʱ��ı�end��ֵ,��ô�����˲�Ƶ�end��λ��,��Ҫ����time�ļ�ʱ��startPos
        
        if (nowTargetPos != endTransform.position)
        {
            time = 0;
            startPos = startTransformB.position;
            nowTargetPos = endTransform.position;

        }

        startTransformB.position = Vector3.Lerp(startPos, nowTargetPos, time);

        // ���β�ֵ
        startTransformC.position = Vector3.Slerp(startTransformC.right * 10, startTransformC.forward * 10, time * 0.1f) ;

    }
}
