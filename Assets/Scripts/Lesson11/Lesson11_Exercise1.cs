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
        // ����Ŀ���
        // Quaternion q = Quaternion.LookRotation(B.position - A.position);
        // A.rotation = q;

        // ʹ����չ�Ĺ�����
        A.MyLookAt(B);
    }
}
