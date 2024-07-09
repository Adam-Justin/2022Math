using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson23 : MonoBehaviour
{
    // LinerRender组件
    private LineRenderer lineRenderer = null;

    // 射线检测
    // 哪些地方应该使用射线:FPS没有实体子弹,没有轨迹的子弹
    // 激光武器,VR中的远程抓取
    // 交互类程序的鼠标点击

    // 构建一条射线 : 射线产生的起始点 + 射线的方向.
    private Ray ray1 = new Ray(Vector3.zero, Vector3.forward);
    // 射线距离
    private float rayDistance = 100.0f;
    // 射线是是否碰撞到了物体
    // bool result = Physics.Raycast(起点, 方向向量 射线长度, 检测层级, 是否检测碰撞器);
    // bool result = Physics.Raycast(射线对象, 射线长度, 检测层级, 是否检测碰撞器);

    // 击中的判定结果
    bool hitResult = false;
    // 射线击中的物体
    private RaycastHit hitInfo;

    void Start()
    {
        // 添加线条绘制组件
        lineRenderer = this.gameObject.AddComponent<LineRenderer>();
        AddLineRender(lineRenderer);

        // 设置射线的起点和方向
        ray1.origin = this.transform.position;
        ray1.direction = this.transform.forward;

        bool result1 = Physics.Raycast(Vector3.zero + new Vector3(0,0,10), Vector3.forward, 1000.0f, 1 << LayerMask.NameToLayer("Default"), QueryTriggerInteraction.UseGlobal);
        if (result1)
        {
            Debug.Log("射线击中物体");
        }
/*        bool result2 = Physics.Raycast(ray1, 1000.0f, 1 << LayerMask.NameToLayer("Default"), QueryTriggerInteraction.UseGlobal);
        if (result2)
        {
            Debug.Log("射线击中物体");
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        // 重新设置射线的位置
        ray1.origin = this.transform.position;
        ray1.direction = this.transform.forward;

        // 旋转游戏对象 -- 每秒旋转60°
        Quaternion quaternion = Quaternion.AngleAxis(60f * Time.deltaTime, this.transform.up);
        this.transform.rotation *= quaternion;        

        // 判断击中的物体
        hitResult =  Physics.Raycast(ray1, out hitInfo, rayDistance, 1 << LayerMask.NameToLayer("Default"), QueryTriggerInteraction.UseGlobal);
        if (hitResult == true)
        {
            print(hitInfo.collider.name);
        }
        // 显示射线
        UpdateLineRendererByRay(lineRenderer, ray1, hitResult,hitInfo, rayDistance);
    }

    /// <summary>
    /// 添加线条渲染组件
    /// </summary>
    void AddLineRender(LineRenderer lineRenderer)
    {
        // lineRenderer = this.gameObject.AddComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = 0.2f;
        lineRenderer.endWidth = 0.2f;
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.green;
    }

    /// <summary>
    /// 射线可可视化
    /// </summary>
    /// <param name="lineRenderer">LineRenderer组件</param>
    /// <param name="ray">射线</param>
    /// <param name="rayDistance">射线距离</param>
    void ShowRayByLineRenderer( LineRenderer lineRenderer,Ray ray, float rayDistance)
    {
        if (lineRenderer == null || lineRenderer.positionCount < 2)
        {
            Debug.Log("LineRender组件不可以使用");
            return;
        }

        // 设置起点位置
        lineRenderer.SetPosition(0, ray.origin);
        lineRenderer.SetPosition(1, ray.GetPoint(rayDistance));
    }

    /// <summary>
    /// 击中物体的时候修改射线的长度
    /// </summary>
    /// <param name="lineRenderer"></param>
    /// <param name="ray"></param>
    /// <param name="hitResult"></param>
    /// <param name="hitInfo"></param>
    /// <param name="rayDistance"></param>
    void UpdateLineRendererByRay(LineRenderer lineRenderer,Ray ray, bool hitResult, RaycastHit hitInfo, float rayDistance)
    {
        if (lineRenderer == null || lineRenderer.positionCount < 2)
        {
            Debug.Log("LineRender组件不可以使用");
            return;
        }

        // 修改起点位置
        lineRenderer.SetPosition(0, ray.origin);
        // 修改终点位置
        if (hitResult == true)
        {
            lineRenderer.SetPosition(1, hitInfo.point);
        }
        else 
        {
            lineRenderer.SetPosition(1, ray.GetPoint(rayDistance));
        }

        
    }
}
