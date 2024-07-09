using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson21 : MonoBehaviour
{
    // linerRender的使用

    private GameObject go;

    private Material material; 

    private void Start()
    {
        // 生成一个空物体
        go = new GameObject("LineRendeObject");
        // 设置父物体
        go.transform.parent = GameObject.Find("Go").transform;

        // 加载材质
       
        // 添加LineRenderer组件
        go.AddComponent<LineRenderer>();
        // 调用检测函数
        TestLinerRenderComponent(go.GetComponent<LineRenderer>());
    }

    /// <summary>
    /// 加载材质资源
    /// </summary>
    /// <param name="newMaterial"></param>
    private void MaterialLoadedCompleted(Material newMaterial)
    {
        material = newMaterial;
    }

    public void TestLinerRenderComponent(LineRenderer lineRenderer)
    {
        if (lineRenderer != null && lineRenderer.enabled)
        {
            // 设置划线组件的具体信息
            // 设置数量
            lineRenderer.positionCount = 4;

            // 设置点的位置
            // 一群点的设置位置
            lineRenderer.SetPositions(new Vector3[]
                {
                    new Vector3(0,0,0),
                    new Vector3(5,0,0),
                    new Vector3(5,0,5),
                    new Vector3(0,0,5)
                });
            // 单个点的设置: 索引+坐标
            // lineRenderer.SetPosition(1, new Vector3(0,0,0));

            // 是否开启循环--封闭图形
            lineRenderer.loop = true;

            // 设置开始宽度
            lineRenderer.startWidth = 0.05f;
            // 设置结束宽度
            lineRenderer.endWidth = 0.05f;

            // 设置开始颜色
            lineRenderer.startColor = Color.red;
            // 设置结束颜色
            lineRenderer.endColor = Color.green;

            // 设置材质 -- 加载材质
            material = Resources.Load<Material>("Material/M_LineRender");
            lineRenderer.material = material;
            // 启用光照影响
            lineRenderer.generateLightingData = true;

            // 设置坐标系
            lineRenderer.useWorldSpace = false;
        }
    }
}
