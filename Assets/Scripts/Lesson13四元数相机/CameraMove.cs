using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform target;                // 摄像机跟随目标
    public float headOffset = 1.0f;         // 摄像机向上偏移位置
    public float angle = 45.0f;             // 倾斜角度

    public float distance = 5.0f;           // 摄像机默认的距离
    public float maxDistance = 10.0f;       // 鼠标控制最大距离
    public float minDistance = 3.0f;        // 鼠标控制最小距离
    public float scrollSpeed = 1.0f;        // 滚轮缩放速度

    private Vector3 nowPosition;            // 摄像机当前位位置

    private Vector3 nowDir;                 // 摄像机位置到目标位置的向量

    public float rotateSpeed = 1.0f;        // 摄像机旋转速度
    public float moveSpeed = 1.0f;          // 摄像机跟随速度
    
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
    /// 摄像机偏移
    /// </summary>
    /// <param name="distance"></param>
    private void CameraFollow(ref float distance)
    {
        // 更新摄像机看向target的向上的位置
        nowPosition = target.position + target.up * headOffset;
        // 后方偏移位置-----将物体的向后的向量绕着right轴转动angle度数, 由于起点是物体的中心点,
        // 那么实际上的效果是这个反向的向量向上提升或向下降低了多少距离,而这个向上或向下的距离
        // 这个向上向下的变化值是通过三角函数可以计算得到的==>通过旋转可以理解为绕着原点旋转, 端点的变化的垂直距离为distance * sin(angle)

        // 获得当前摄像机与target目标的向量
        nowDir = Quaternion.AngleAxis(angle, target.right) * (-this.transform.forward);

        nowPosition = nowPosition + nowDir * distance;
        // this.transform.position = nowPosition; 
        this.transform.position = Vector3.Slerp(this.transform.position, nowPosition, Time.deltaTime * moveSpeed);
        Debug.DrawLine(this.transform.position, target.position + target.up * headOffset, Color.green);

        // 旋转摄像机 -- 使用先快后慢的旋转方式
        // this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(-nowDir), Time.deltaTime * rotateSpeed);

        // 被修改为
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(-target.up), Time.deltaTime * rotateSpeed);
        
    }

    /// <summary>
    /// 滚轮修改摄像机距离物体的距离
    /// </summary>
    /// <param name="distance">外部传入的距离</param>
    private void ChangeCameraDistance(ref float distance, float minDistance, float maxDistance, float scrollSpeed)
    {
        // 鼠标滚轮修改摄像机距离Taget的距离
        distance += Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        // 将距离限制在[Min, Max]范围内
        distance = Mathf.Clamp(distance, minDistance, maxDistance);
    }
}
