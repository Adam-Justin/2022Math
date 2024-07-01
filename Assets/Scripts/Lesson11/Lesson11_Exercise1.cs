using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson11_Exercise1 : MonoBehaviour
{
    public Transform A;
    public Transform B;

    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 看向目标点
        // Quaternion q = Quaternion.LookRotation(B.position - A.position);
        // A.rotation = q;

        // 使用扩展的工具类
        A.MyLookAt(B);
    }
}
