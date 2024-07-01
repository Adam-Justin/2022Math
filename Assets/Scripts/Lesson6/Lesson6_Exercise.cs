using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson6_Exercise : MonoBehaviour
{

    // 检测玩家前方5米内,45°内的敌人
    public GameObject gameObject;

    float distance = 5.0f;
    float angel = 0.0f;
    float dotResult = 0.0f; // 点乘结果
    void Update()
    {
        
        if (Vector3.Distance(this.transform.position, gameObject.transform.position) <= distance)
        {
            dotResult = Vector3.Dot(this.transform.forward, (gameObject.transform.position - this.transform.position).normalized);
            angel = Mathf.Acos(dotResult) * Mathf.Rad2Deg;
            if (angel <= 22.5)
            {
                Debug.DrawLine(this.transform.position, gameObject.transform.position, Color.red);
                Debug.Log("发现敌人");
            }
        }
    }
}
