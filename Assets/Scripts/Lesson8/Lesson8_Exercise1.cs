using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson8_Exercise1 : MonoBehaviour
{
    // 线性插值--摄像机跟随
    public Transform targetTransform;

    public float distanceBehind = 4.0f; // 摄像机距离物体的距离
    public float heightOffset = 7.0f; // 摄像机的高度偏移
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 设置摄像机的看向的位置
        Vector3 targetPosition = targetTransform.position - targetTransform.forward * distanceBehind + Vector3.up * heightOffset;

        // 摄像机平滑移动
        this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, Time.deltaTime);
        // 摄像机看向目标
        this.transform.LookAt(targetPosition);

        Debug.Log(Camera.main.transform.position);
    }
}
