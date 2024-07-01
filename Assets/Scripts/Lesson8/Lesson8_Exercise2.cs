using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson8_Exercise2 : MonoBehaviour
{
    // 球形插值--太阳东升西落下
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
            // 重置终点
            nowTargetPos = targetPos;
            // 重置起点
            startPos = this.transform.position;
            // 重置比例计时
            time = 0;

        }
        this.transform.position = Vector3.Slerp(startPos, targetPos, time * 0.1f);
        
       

    }
}
