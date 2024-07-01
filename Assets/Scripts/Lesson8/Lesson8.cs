using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson8 : MonoBehaviour
{
    public Transform startTransformA;
    public Transform startTransformB;
    public Transform endTransform;
    [Header("球形插值")]
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
        // 计算公式: result  =  start + (end - start) * t;
        // 第一种
        startTransformA.position = Vector3.Lerp(startTransformA.position, endTransform.position, Time.deltaTime);
        Debug.DrawLine(startTransformA.position, endTransform.position, Color.green);

        // 第二种
        time += Time.deltaTime;
        // time >=1 的时候就到达了终点,如果在t>=1的时候改变end的值,那么物体会瞬移到end的位置,需要重置time的计时和startPos
        
        if (nowTargetPos != endTransform.position)
        {
            time = 0;
            startPos = startTransformB.position;
            nowTargetPos = endTransform.position;

        }

        startTransformB.position = Vector3.Lerp(startPos, nowTargetPos, time);

        // 球形插值
        startTransformC.position = Vector3.Slerp(startTransformC.right * 10, startTransformC.forward * 10, time * 0.1f) ;

    }
}
