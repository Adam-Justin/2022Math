using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson11_Exercise2 : MonoBehaviour
{
    // 实现摄像机看向玩家
    public Transform targetTransform;


    [Header("摄像机移动相关")]
    public float distanceBehind = 4.0f;         // 摄像机距离物体的距离
    public float heightOffset = 7.0f;           // 摄像机的高度偏移

    private Vector3 startPosition;              // 摄像机起点位置
    private Vector3 targetPosition;             // 摄像机终点位置
    private float moveTime = 0.0f;
    public float moveSpeed = 1.0f;              // 移动速度

    [Header("摄像机旋转相关")]
    private float roundTime = 0.0f;
    private Quaternion startRotation;           // 摄像机旋转起点
    private Quaternion targetRotation;          // 摄像机旋转终点
    public float roundSpeed = 1.0f;             // 摄像机旋转速度


    void Start()
    {
        // 初始化起点
        // 可以不用初始化
        targetPosition = targetTransform.position - targetTransform.forward * distanceBehind + Vector3.up * heightOffset;
        targetRotation = Quaternion.LookRotation(targetTransform.position - this.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        CameraFollow();
    }


    /// <summary>
    /// 摄像机跟随-包含移动和旋转
    /// </summary>
    private void CameraFollow()
    {
        CameraFollowMoveAverage();
        CameraFollowRotateAverage();
    }
    /// <summary>
    /// 摄像机先快后慢跟随
    /// </summary>
    private void CameraFollowMoveFast()
    {
        targetPosition = targetTransform.position - targetTransform.forward * distanceBehind + Vector3.up * heightOffset;
        // 先快后慢
        startPosition = this.transform.position;
        this.transform.position = Vector3.Slerp(startPosition, targetPosition, Time.deltaTime * moveSpeed);
    }

    /// <summary>
    /// 摄像机平滑跟随
    /// </summary>
    private void CameraFollowMoveAverage()
    {
        // 摄像机平滑移动
        if (targetPosition != targetTransform.position - targetTransform.forward * distanceBehind + Vector3.up * heightOffset)
        {
            // 重置终点
            targetPosition = targetTransform.position - targetTransform.forward * distanceBehind + Vector3.up * heightOffset;
            // 重置时间
            moveTime = 0.0f;
            // 重置起点
            startPosition = this.transform.position;

        }
        moveTime += Time.deltaTime;
        this.transform.position = Vector3.Slerp(startPosition, targetPosition, moveTime * moveSpeed);
    }

    /// <summary>
    /// 摄像跟随物体匀速旋转
    /// </summary>
    private void CameraFollowRotateAverage()
    {
        // 匀速运动 --第一次起点和终点不变, 后面的时候起点和终点要变
        if (targetRotation != Quaternion.LookRotation(targetTransform.position - this.transform.position))
        {
            // 重置终点
            targetRotation = Quaternion.LookRotation(targetTransform.position - this.transform.position);
            // 重置时间
            roundTime = 0.0f;
            // 重置起点
            startRotation = this.transform.rotation;
        }
        roundTime += Time.deltaTime;
        this.transform.rotation = Quaternion.Slerp(startRotation, targetRotation, roundTime);
    }

    /// <summary>
    /// 摄像机先快后跟着物体旋转
    /// </summary>
    public void CameraFollowRotateFast()
    {
        // 构建旋转四元数
        targetRotation = Quaternion.LookRotation(targetTransform.position - this.transform.position);
        // Slerp旋转缓动效果

        // 先快后慢 -- 自己的四元数-目标四元素-Time.deltaTime
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetRotation, Time.deltaTime * roundSpeed);
    }
}
